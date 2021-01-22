    List<Asset> assets = (from asset in xmlDocument.Descendants("asset")
                                  select new Asset
                                  {
                                      ItemType = asset.Elements().Single(x => x.Attribute("Id").Value == "ItemType").Attribute("Value").Value,
                                      ItemUri = asset.Elements().Single(x => x.Attribute("Id").Value == "ItemUri").Attribute("Value").Value,    
                                  }).ToList<Asset>();
