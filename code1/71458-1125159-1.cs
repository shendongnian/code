        XDocument doc = XDocument.Parse(xml);
        var qry = from cat in doc.Root.Elements("category")
                  where (string)cat.Element("name") == "First Category"
                  from prod in cat.Elements("product")
                  select new
                  {
                      Name = (string)prod.Element("name"),
                      Order = (int)prod.Element("order")
                  };
        foreach (var prod in qry)
        {
            Console.WriteLine("{0}: {1}", prod.Order, prod.Name);
        }
