                var contacts = (from c in loaded.Descendants("Countries")
                               select new
                               {
                                   Country = c.Element("Country").Value,
                                   Region = c.Element("region").Value,
                                   Province= c.Element("province").Value,
                                   City = c.Element("city").Value,
                                   Hotel = c.Element("hotel").Value
                               }).ToList();
