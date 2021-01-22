    string id = yourDocument
                    .Descendants("Pricing")
                    .Descendants<XElement>("MPrice")
                    .Where<XElement>(i => i.Descendants("Price")
                                            .Descendants<XElement>("StartDt")
                                            .Select<XElement, DateTime>(s => DateTime.Parse(s.Value))
                                            .FirstOrDefault<DateTime>() == DateTime.Now)
                    .Select<XElement, string>(i => i.Descendants("Id").FirstOrDefault<XElement>().Value)
                    .FirstOrDefault<string>();
                
                
