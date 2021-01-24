    using System;
    using System.Collections.Generic;
    using LINQtoCSV;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                csvParse();
                Console.ReadLine();
            }
    
            private static void csvParse()
            {
                string fileName = "../../../test.csv"; // provide a valid path to the file
    
                CsvContext cc = new CsvContext();
    
                CsvFileDescription inputFileDescription = new CsvFileDescription
                {
                    SeparatorChar = ',',
                    FirstLineHasColumnNames = true,
                    IgnoreUnknownColumns = true // add this line
                };
    
                IEnumerable<orderProduct> fromCSV = cc.Read<orderProduct>(fileName, inputFileDescription);
    
                foreach (var d in fromCSV)
                {
                    Console.WriteLine($@"Product:{d.product},Quantity:""{d.orderQty}"",Price:""{d.price}""");
                }
            }
        }
    
        public class orderProduct
        {
            public orderProduct() { }
            public string product { get; set; }
            public string price { get; set; }
            public string orderQty { get; set; }
            public string value { get; set; }
    
            public string calculateValue()
            {
                return (Convert.ToDouble(price) * Convert.ToDouble(orderQty)).ToString();
            }
        }
    }
