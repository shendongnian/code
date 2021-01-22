            XNamespace blank = XNamespace.Get(@"http://www.sitemaps.org/schemas/sitemap/0.9");
            XNamespace xsi = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema-instance");
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(blank + "urlset",
                    new XAttribute("xmlns", blank.NamespaceName), 
                    new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),
                    new XElement(blank + "url",
                        new XElement(blank + "loc", "http://www.xyz.eu/"),
                        new XElement(blank + "lastmod", "2010-01-20T10:56:47Z"),
                        new XElement(blank + "changefreq", "daily"),
                        new XElement(blank + "priority", "1"))
                 ));
            Console.WriteLine(doc.ToString());
