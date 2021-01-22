    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.ExceptionServices;
    
    namespace ExceptionCatching
    {
        public class Test
        {
            public void StackOverflow()
            {
                StackOverflow();
            }
    
            public void CustomException()
            {
                throw new Exception();
            }
    
            public unsafe void AccessViolation()
            {
                byte b = *(byte*)(8762765876);
            }
        }
    
        class Program
        {
            [HandleProcessCorruptedStateExceptions]
            static void Main(string[] args)
            {
                Test test = new Test();
                try {
                    //test.StackOverflow();
                    test.AccessViolation();
                    //test.CustomException();
                }
                catch
                {
                    Console.WriteLine("Caught.");
                }
    
                Console.WriteLine("End of program");
                
            }
    
        }      
    }
