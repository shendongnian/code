    class Program
    {
        public static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"Path to your xml file");
            XNamespace ns = doc.Root.GetDefaultNamespace();
            XNamespace xdt = "http://www.3gpp.org";
            var result = doc.Descendants(ns + "TestElement")
            .Elements(ns + "InventoryUnit")
            .Elements(ns + "InventoryUnit")
            .Select(x => new
            {
                test_element_name = x.AncestorsAndSelf(ns + "TestElement").FirstOrDefault()?.Attribute("id")?.Value,
                slot_data = x.Ancestors(ns + "InventoryUnit").AncestorsAndSelf(ns + "InventoryUnit").FirstOrDefault().Element(ns + "attributes").Element(ns + "manufacturerData")?.Value,
                invenotry_unit_number = x.Element(ns + "attributes").Element(ns + "vendorUnitTypeNumber")?.Value,
            }).ToList();
    
            //-----------Print result--------------
            foreach (var item in result)
            {
                Console.WriteLine(item.test_element_name);
                Console.WriteLine(item.slot_data);
                Console.WriteLine(item.invenotry_unit_number);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
