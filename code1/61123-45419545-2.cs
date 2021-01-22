    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace SingletonTest
    {
        class MySingleton
        {
            static public MySingleton Instance { get; } = new MySingleton();
    
            private MySingleton() { Console.WriteLine("Created MySingleton"); }
    
            public void DoSomething() { Console.WriteLine("DoSomething"); }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting Main");
    
                MySingleton.Instance.DoSomething();
            }
        }
    }
