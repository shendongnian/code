    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;
    
    namespace dateconvert
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime x = Convert.ToDateTime("02/28/10");
                Console.WriteLine(string.Format(x.ToString("d", DateTimeFormatInfo.InvariantInfo)));
                DateTime y = Convert.ToDateTime("May 25, 2010");
                Console.WriteLine(string.Format(y.ToString("d", DateTimeFormatInfo.InvariantInfo)));
                DateTime z = Convert.ToDateTime("12 May 2010");
                Console.WriteLine(string.Format(z.ToString("d", DateTimeFormatInfo.InvariantInfo)));
                Console.Read();
            }
        }
    }
