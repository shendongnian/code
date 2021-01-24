    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace ConsoleApp12
    {
        class Program
        {
    
    
    
            static void Main(string[] args)
            {
                var str =
    @"BFFPPB14 Dark Chocolate Dried Cherries 14 oz (397g)
    
    INGREDIENTS: DARK CHOCOLATE (SUGAR, CHOCOLATE LIQUOR, COCOA BUTTER, ANHYDROUS MILK FAT, SOYA LECITHIN, VANILLIN [AN ARTIFICIAL FLAVOR]), DRIED TART CHERRIES (CHERRIES, SUGAR), GUM ARABIC, CONFECTIONER'S GLAZE.
    
    CONTAINS: MILK, SOY
    
    ALLERGEN INFORMATION: MAY CONTAIN TREE NUTS, PEANUTS, EGG AND WHEAT.
    
    01/11/2019
    
    Description: Sweetened dried Montmorency cherries that are panned with dark chocolate.
    
    Storage Conditions: Store at ambient temperatures with a humidity less than 50%. Shelf Life: 9 months
    
    Company Name
    
    Item No.: 701804
    
    Bulk: 415265
    
    Supplier: Cherryland's Best
    
    WARNING: CHERRIES MAY CONTAIN PITS
    ";
    
                var lines = str.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
    
    
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
