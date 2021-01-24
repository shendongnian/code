    XmlSerializer serializer = new XmlSerializer(new TestDataFile().GetType());
    using (StringReader stringReader = new StringReader(File.ReadAllText(@"Path to your xml file")))
    {
        TestDataFile testDataFile = (TestDataFile)serializer.Deserialize(stringReader);
        var result = testDataFile.TestElement.SelectMany(x => x.InventoryUnit.SelectMany(y => y.IU
                                              .Select(z => new { test_element_name = x.Id, slot_data = y.Attributes.ManufacturerData, invenotry_unit_number = z.Attributes.VendorUnitTypeNumber }))).ToList();
        foreach (var item in result)
        {
            Console.WriteLine(item.test_element_name);
            Console.WriteLine(item.slot_data);
            Console.WriteLine(item.invenotry_unit_number);
            Console.WriteLine();
        }
    }
