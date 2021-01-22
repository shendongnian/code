        string[] categories = { "Tasties", "Pasta", "Chicken" };
        XDocument doc = XDocument.Parse(xml);
        IEnumerable<XElement> query = doc.Elements();
        foreach (string category in categories) {
            string tmp = category;
            query = query.Elements("Category")
                .Where(c => c.Attribute("Name").Value == tmp);
        }
        foreach (string name in query.Descendants("Recipe")
            .Select(r => r.Attribute("Name").Value)) {
            Console.WriteLine(name);
        }
