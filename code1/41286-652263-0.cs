        public List<Listing> GetList()
        {
            if (File.Exists(this.xmlFilePath))
            {
                XDocument doc = XDocument.Load(this.xmlFilePath);
                var listings = from row in doc.Root.Elements("listing")
                               select new Listing
                               {
                                   A = (string)row.Element("A"),
                                   B = (string)row.Element("B"),
                                   C = (string)row.Element("C"),
                                   D = (string)row.Element("D"),
                                   E = (string)row.Element("E")
                               };
                return listings.ToList();
            }
            else
            {
                return new List<Listing>();
            }
        }
