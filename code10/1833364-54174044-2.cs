    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApp12
    {
        class Program
        {
            public static void Main(string[] args)
            {
                // test string
                var str = @"BFFPPB10 Dark Chocolate Macadamia Nuts 11 oz (312g)\r\nINGREDIENTS: DARK CHOCOLATE (SUGAR, CHOCOLATE, COCOA BUTTER, \r\nANHYDROUS MILK FAT, SOY LECITHIN, VANILLA), MACADAMIA NUTS, SEA SALT.\r\nCONTAINS: MACADAMIA NUTS, MILK, SOY.\r\nALLERGEN INFORMATION: MAY CONTAIN OTHER TREE NUTS, PEANUTS, EGG AND\r\nWHEAT.\r\n01/11/2019\r\nDescription: Dry roasted, salted macadamias covered in dark chocolate.\r\nStorage Conditions: Store at ambient temperatures with a humidity less than 50%. \r\nShelf Life: 12 months\r\nBlain's Farm & Fleet\r\nItem No.: 701772\r\nBulk: 421172\r\nSupplier: Devon's\r\n";
                // Keys
                const string KEY_INGREDIENTS = "INGREDIENTS:";
                const string KEY_CONTAINS = "CONTAINS:";
                const string KEY_ALLERGEN_INFORMATION = "ALLERGEN INFORMATION:";
                const string KEY_DESCRPTION = "Description:";
                const string KEY_STORAGE_CONDITION = "Storage Conditions:";
                const string KEY_SHELFLIFE = "Shelf Life:";
                const string KEY_ITEM_NO = "Item No.:";
                const string KEY_BULK = "Bulk:";
                const string KEY_SUPPLIER = "Supplier:";
                const string KEY_WARNING = "WARNING:";
                const string KEY_YEAR_Regex = @"^\d{1,2}/\d{1,2}/\d{4}$";
                const string KEY_AFTER_COMPANY_NAME = KEY_ITEM_NO;
                // Helpers
                var keys = new string[]
                { KEY_INGREDIENTS, KEY_CONTAINS, KEY_ALLERGEN_INFORMATION, KEY_DESCRPTION, KEY_STORAGE_CONDITION,
                    KEY_SHELFLIFE, KEY_ITEM_NO, KEY_BULK, KEY_SUPPLIER, KEY_WARNING };
                var lines = str.Split(new string[] { @"\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                void log(string key, string val)
                {
                    Console.WriteLine($"{key} =>  {val}");
                    Console.WriteLine();
                }
                void removeLine(string line)
                {
                    if (line != null) lines = lines.Where(w => w != line).ToArray();
                }
                // get Multi Line Item with key
                string getMultiLine(string key)
                {
                    var line = lines
                                .Select((linetxt, index) => new { linetxt, index })
                                    .Where(w => w.linetxt.StartsWith(key))
                                    .FirstOrDefault();
                    if (line == null) return string.Empty;
                    var result = line.linetxt;
                    for (int i = line.index + 1; i < lines.Length; i++)
                    {
                        if (!keys.Any(a => lines[i].StartsWith(a)))
                            result += lines[i];
                        else
                            break;
                    }
                    return result;
                }
                // get single Line Item before spesic key if the Line is not a key
                string getLinebefore(string the_after_key)
                {
                    var the_after_line = lines
                                .Select((linetxt, index) => new { linetxt, index })
                                    .Where(w => w.linetxt.StartsWith(the_after_key))
                                    .FirstOrDefault();
                    if (the_after_line == null) return string.Empty;
                    var the_before_line_text = lines[the_after_line.index - 1];
                    //not a key
                    if (!keys.Any(a => the_before_line_text.StartsWith(a)))
                        return the_before_line_text;
                    else
                        return null;
                }
                // 1st get item without key
                var itemName = lines.FirstOrDefault();
                removeLine(itemName);
                var year = lines.Where(w => Regex.Match(w, KEY_YEAR_Regex).Success).FirstOrDefault();
                removeLine(year);
                var companyName = getLinebefore(KEY_AFTER_COMPANY_NAME);
                removeLine(companyName);
                //2nd get item with Keys
                var ingredients = getMultiLine(KEY_INGREDIENTS);
                var contanins = getMultiLine(KEY_CONTAINS);
                var allergenInfromation = getMultiLine(KEY_ALLERGEN_INFORMATION);
                var description = getMultiLine(KEY_DESCRPTION);
                var storageConditions = getMultiLine(KEY_STORAGE_CONDITION);
                var shelfLife = getMultiLine(KEY_SHELFLIFE);
                var itemNo = getMultiLine(KEY_ITEM_NO);
                var bulk = getMultiLine(KEY_BULK);
                var supplier = getMultiLine(KEY_SUPPLIER);
                var warning = getMultiLine(KEY_WARNING);
                // 3rd log
                log("ItemName", itemName);
                log("Ingredients", ingredients);
                log("contanins", contanins);
                log("Allergen Infromation", allergenInfromation);
                log("Year", year);
                log("Description", description);
                log("Storage Conditions", storageConditions);
                log("Shelf Life", shelfLife);
                log("CompanyName", companyName);
                log("Item No", itemNo);
                log("Bulk", bulk);
                log("Supplier", supplier);
                log("warning", warning);
                Console.ReadLine();
            }
        }
    }
