         using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {     
            public static string ReverseString(string str)
            {
                int totalLength = str.Length;
                int iCount = 0;
                string strRev = string.Empty;
                iCount = totalLength;
                while (iCount != 0)
                {
                    iCount--;
                    strRev += str[iCount]; 
                }
                return strRev;
            }
            static void Main(string[] args)
            {
                string str = "Punit Pandya";
                string strResult = ReverseString(str);
                Console.WriteLine(strResult);
                Console.ReadLine();
            }
        }
    
      }
