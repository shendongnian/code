    var contacts = (from c in loaded.Descendants("Countries")
                            select new
                            {
                                Country = (string)c.Attribute("ountry").Value,
                                Region = (string)c.Element("Regions").Attribute("region").Value,
                                Province = (string)c.Element("Provinces").Attribute("province").Value,
                                City = (string)c.Element("Cities").Attribute("city").Value,
                                Hotel = (string)c.Alement("Hotels").Attribute("hotel").Value
                            }).ToList();
