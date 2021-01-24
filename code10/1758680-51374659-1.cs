    static void Main(string[] args)
    {
    var xml =
    @"<departments>
    <department id=""1"" name=""Sporting Goods"">
    <products>
    <product name=""Basketball"" price=""9.99"">
    <add key=""Color"" value=""Orange"" />
    <add key=""Brand"" value=""[BrandName]"" />
    </product>
    </products>
    </department>
    </departments>";
    
    var xDoc = XDocument.Load(new StringReader(xml));
    
    var adds = xDoc.Root.Elements("department")
                        .Elements("products")
                        .Elements("product")
                        .Elements("add")
                        .Select(s => new KeyValuePair<string, string>(s.Attribute("key").ToString(), s.Attribute("value").ToString()))
                        .ToList();
    
    foreach (var department in xDoc.Root.Elements("department"))
    {
        Console.WriteLine("department: {0}", department.Attribute("name"));
        foreach (var products in department.Elements("products"))
        {
            foreach (var product in products.Elements("product"))
            {
                Console.WriteLine("product: {0}", product.Attribute("name"));
                foreach (var config in product.Elements("add"))
                {
                    Console.WriteLine("add: {0} -> {1}", config.Attribute("key"), config.Attribute("value"));
                }
            }
        }
    }
