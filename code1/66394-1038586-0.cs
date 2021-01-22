    using System;
    
    namespace ConsoleApplication67
    {
        class Program
        {
            static void Main()
            {
                WriteRatio(4);
                WriteRatio(0);
                WriteRatio(-200);
    
                Console.ReadLine();
            }
    
            private static void WriteRatio(int i)
            {
                Console.WriteLine(string.Format(@"{0:1\:0;-1\:0;\0}", i));
            }
        }
    }
