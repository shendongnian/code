        XmlDocument root = new XmlDocument();
        root.LoadXml(xml); // or .Load(path);
        var categories = root.SelectNodes(
            "/root/Product/Product/Product/@category")
            .Cast<XmlNode>().Select(cat => cat.InnerText).Distinct();
        var sortedCategories = categories.OrderBy(cat => cat);
        foreach (var category in sortedCategories)
        {
            Console.WriteLine(category);
        }
        var totalItems = root.SelectNodes(
             "/root/Products/Product/Product").Count;
        Console.WriteLine(totalItems);
        foreach (XmlElement prod in root.SelectNodes(
            "/root/Product/Product[@desc='Costly']/Product"))
        {
            Console.WriteLine(prod.GetAttribute("desc"));
        }
