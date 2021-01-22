            string xml = @"your XML";
            XDocument doc = XDocument.Parse(xml);
            var products = from category in doc.Element("catalog").Elements("category")
                           where category.Element("name").Value == "First Category"
                           from product in category.Elements("product")
                           select new
                           {
                               Name = product.Element("name").Value,
                               Order = product.Element("order").Value
                           };
            foreach (var item in products)
            {
                Console.WriteLine("Name: {0} Order: {1}", item.Name, item.Order);
            }
