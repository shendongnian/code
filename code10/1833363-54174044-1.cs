    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApp12
    {
        class Program
        {
            public static void Main(string[] args)
            {
                var  str =@"BFFPPB10 Dark Chocolate Macadamia Nuts 11 oz (312g)\r\nINGREDIENTS: DARK CHOCOLATE (SUGAR, CHOCOLATE, COCOA BUTTER, \r\nANHYDROUS MILK FAT, SOY LECITHIN, VANILLA), MACADAMIA NUTS, SEA SALT.\r\nCONTAINS: MACADAMIA NUTS, MILK, SOY.\r\nALLERGEN INFORMATION: MAY CONTAIN OTHER TREE NUTS, PEANUTS, EGG AND\r\nWHEAT.\r\n01/11/2019\r\nDescription: Dry roasted, salted macadamias covered in dark chocolate.\r\nStorage Conditions: Store at ambient temperatures with a humidity less than 50%. \r\nShelf Life: 12 months\r\nBlain's Farm & Fleet\r\nItem No.: 701772\r\nBulk: 421172\r\nSupplier: Devon's\r\n";
                var lines = str.Split(new string[] { @"\r\n" }, StringSplitOptions.None).ToList();
                var ItemName = lines.FirstOrDefault();
                string INGREDIENTS = lines.Where(w => w.ToLower().StartsWith("INGREDIENTS".ToLower())).FirstOrDefault();
                string CONTAINS = lines.Where(w => w.ToLower().StartsWith("CONTAINS".ToLower())).FirstOrDefault();
                string ALLERGEN = lines.Where(w => w.ToLower().StartsWith("ALLERGEN".ToLower())).FirstOrDefault();
                string Year = lines.Where(w => Regex.Match(w, @"^\d{1,2}/\d{1,2}/\d{4}$").Success).FirstOrDefault();
                string Description = lines.Where(w => w.ToLower().StartsWith("Description".ToLower())).FirstOrDefault();
                string CompanyName = lines.Where(w => w.ToLower().StartsWith("Company Name".ToLower())).FirstOrDefault();
                string ItemNo = lines.Where(w => w.ToLower().StartsWith("Item No".ToLower())).FirstOrDefault();
                string Bulk = lines.Where(w => w.ToLower().StartsWith("Bulk".ToLower())).FirstOrDefault();
                string Supplier = lines.Where(w => w.ToLower().StartsWith("Supplier".ToLower())).FirstOrDefault();
                string WARNING = lines.Where(w => w.ToLower().StartsWith("WARNING".ToLower())).FirstOrDefault();
                Console.WriteLine($"Item Name = {ItemName}");
                Console.WriteLine($"INGREDIENTS = {INGREDIENTS}");
                Console.WriteLine($"CONTAINS = {CONTAINS}");
                Console.WriteLine($"ALLERGEN = {ALLERGEN}");
                Console.WriteLine($"Year = {Year}");
                Console.WriteLine($"Description = {Description}");
                Console.WriteLine($"CompanyName = {CompanyName}");
                Console.WriteLine($"ItemNo = {ItemNo}");
                Console.WriteLine($"Bulk = {Bulk}");
                Console.WriteLine($"Supplier = {Supplier}");
                Console.WriteLine($"WARNING = {WARNING}");
                Console.ReadLine();
            }
 
        }
    }
