    using System;
    
    namespace ConsoleApp4
    {
        interface IBob
        {
            void foo();
        }
    
        class A : IBob
        {
            void IBob.foo()
            {
                Console.WriteLine("A");
            }
    
            public virtual void foo()
            {
                ((IBob)this).foo();
            }
        }
    
        class B : A
        {
            public override void foo()
            {
                Console.WriteLine("B");
            }
        }
    
        class C : B
        {
            public override void foo()
            {
                Console.WriteLine("C");
    
                // Writes B
                base.foo();
    
                // Writes A
                ((IBob)this).foo();
            }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                var sally = new C();
                sally.foo(); // A B C
    
                IBob sally2 = sally;
                sally2.foo(); // A
    
                Console.ReadLine();
            }
        }
    }
