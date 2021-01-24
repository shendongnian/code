    List<Product> productList = new List<Product>();
    XDocument xdocument = XDocument.Parse(responseAsString);
    XNamespace ns = "http://base.google.com/ns/1.0";
    var products = from x in xdocument.Elements(ns + "rss")
                   from y in x.Elements(ns + "channel")
                   from z in y.Elements(ns + "item")
                   select z;
    foreach (var product in products)
    {
        var prod = new Product();
        productList.Add(prod);
        foreach (XElement el in product.Elements())
        {
            if (el.Name == ns + "id")
            {
                prod.SKU = el.Value.Replace("-master", string.Empty);
            }
            else if (el.Name == ns + "availability")
            {
                prod.Availability = el.Value == "in stock";
            }
        }
    }
