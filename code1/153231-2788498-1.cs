     var contacts = (from c in loaded.Descendants("Countries")
                               select new
                               {
                                   Country = c.Element("Countries").Value,
                                   Region = c.Element("Regions").Value,
                                   Province= c.Element("Provinces").Value,
                                   City = c.Element("Cities").Value,
                                   Hotel = c.Element("Hotels").Value
                               }).ToList();
