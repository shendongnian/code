    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                
                DateTime expiryDate = DateTime.ParseExact("15/06/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(int.Parse("2"));
                DateTime expiryDate2 = DateTime.ParseExact("15/06/2018 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).AddMonths(int.Parse("2"));
    
                Console.WriteLine(expiryDate); //15.08.2018 00:00:00
                Console.WriteLine(expiryDate2); //15.08.2018 00:00:00
            }
        }
    }
