                XNamespace ns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");
            XElement urlset = null;
            XDocument siteMapDocument = new XDocument(urlset = new XElement(ns + "urlset"));
            foreach (var links in siteMap.SiteMapUrls)
            {
                urlset.Add(new XElement
                (ns + "url",
                new XElement(ns + "loc",links.Location),
                new XElement(ns + "lastmod", DateTime.Now),
                new XElement(ns + "changefreq", Enum.GetName(typeof(SiteMapUrlChangeFreqs), links.ChangeFreq)),
                new XElement(ns + "priority", "0.2")
                ));
            }
			siteMapDocument.Save(String.Format("{0}\\{1}",AppDomain.CurrentDomain.BaseDirectory,"SiteMap.xml"));
