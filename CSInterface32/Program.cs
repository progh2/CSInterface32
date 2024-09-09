using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSInterface32
{
    internal class Program
    {
        class TestClass : IBasic
        {
            public int TestProperty {
                get { return -1; }
                set { int n = value; } 
            }

            public int TestInstanceMethod()
            {
                // do something
                return -1;
            }
        }

        class Dummy : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Dispose() 메서드 호출됨");
            }
        }

        class Product : IComparable<Product>
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public int CompareTo(Product other)
            {
                return this.Price.CompareTo(other.Price);
                //return this.Name.CompareTo(other.Name);
            }

            public override string ToString()
            {
                return Name + " : " + Price;
            }
        }

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Name = "감자", Price = 1500 },
                new Product() { Name = "고구마", Price = 5000 },
                new Product() { Name = "양파", Price = 1400 },
                new Product() { Name = "배추", Price = 2300 },
                new Product() { Name = "상추", Price = 1300 },
            };

            products.Sort();

            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            using(Dummy dummy = new Dummy())
            {
                Console.WriteLine("using 블록 안에 들어왔습니다.");
            }
            Console.WriteLine("using 블록을 벗어났습니다.");

            // 다형성의 예 - 다양한 얼굴(역할)을 가졌다!
            TestClass tc = new TestClass();
            IBasic ib = tc;
            IBasic ib2 = new TestClass();
            TestClass tc2 = (TestClass)ib2;
            TestClass tc3 = (TestClass)ib;
        }
    }
}
