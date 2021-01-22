    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net;
    using System.Configuration;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                CommaDelimitedStringCollection commaStr = new CommaDelimitedStringCollection();
                string[] itemList = { "Test1", "Test2", "Test3" };
                commaStr.AddRange(itemList);
                Console.WriteLine(commaStr.ToString()); //Outputs Test1,Test2,Test3
                Console.ReadLine();
            }
        }
    }
