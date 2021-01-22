    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime dt1 = DateTime.Parse("09/08/2012");
                DateTime dt2 = DateTime.Parse(DateTime.Now.ToString());
                int days = (dt2 - dt1).Days;
                Console.WriteLine(days);
    
                double month = (dt2 - dt1).Days / 30;
                Console.WriteLine(month);
                double year = (dt2 - dt1).Days / 365;
                Console.WriteLine(year);
                Console.Read();
            }
        }
    }
