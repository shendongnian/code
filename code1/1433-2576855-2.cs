    using System;
    
    namespace TestStaticDestructor
    {
        class StaticDestructor
        {
            public delegate void Handler();
            private Handler doDestroy;
    
            public StaticDestructor(Handler method)
            {
                doDestroy = method;
            }
    
            ~StaticDestructor()
            {
                doDestroy();
            }
        }
    
        class SomeClass
        {
            static SomeClass()
            {
                Console.WriteLine("Statically constructed!");
            }
    
            static readonly StaticDestructor destructor = new StaticDestructor(
                delegate()
                {
                    Console.WriteLine("Statically destructed!");
                }
            );
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                SomeClass someClass = new SomeClass();
                someClass = null;
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
