                var contacts = (from c in loaded.Descendants("Countries")
                               select new
                               {
                                   Country = c.Attribute("country").Value,
                                   Region = c.Descendants("Regions").FirstOrDefault().Attribute("region")Value,
                                   Province= c.Descendants("Provinces").FirstOrDefault().Attribute("province").Value,
                                   City = c.Descendants("Cities").FirstOrDefault().Attribute("city").Value,
                                   Hotel = c.Descendants("Hotels").FirstOrDefault().Attribute("hotel").Value
                               }).ToList();
