    var contacts = (from c in loaded.Descendants("Countries")
                            select new
                            {
                                Country = (string)c.Attribute("Country").Value,
                                Region = (string)c.Element("Regions").Attribute("region").Value,
                                Province = (string)c.Element("Regions").Element("Provinces").Attribute("province").Value,
                                City = (string)c.Element("Regions").Element("Provinces").Element("Cities").Attribute("city").Value,
                                Hotel = (string)c.Element("Hotels").Attribute("hotel").Value
                            }).ToList();
