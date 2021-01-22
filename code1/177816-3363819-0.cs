    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace CallSequence
    {
        internal class Test
        {
            internal Test()
            {
                Console.WriteLine("non-static constructor");
            }
    
            static Test()
            {
                Console.WriteLine("static constructor");
            }
    
            static int myField = InitMyField();
    
            static int InitMyField()
            {
                Console.WriteLine("static method : (InitMyField)");
                return 0;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Test t = new Test();
            }
        }
    }
