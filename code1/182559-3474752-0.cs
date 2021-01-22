    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                foreach (var item in typeof(Foo).GetProperties())
                    Console.WriteLine(item.Name);
    
                Console.ReadKey();
            }
    
            public class Foo
            {
                public int Bar { get; set; }
    
                public string StringBar
                {
                    get { return Bar.ToString(); }
                }
    
                public void DoSomething()
                {
                }
            }
    
        }
    }
