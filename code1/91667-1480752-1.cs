    using System; 
    using System.Collections.Generic; 
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "this is a test 1,2,3";
                int length = CountAllNumbersAndChar(str);    
                Console.WriteLine(length);
            }
    
            public static int CountAllNumbersAndChar(string str) 
            { 
                return str.Length; 
            }
        }
    }
