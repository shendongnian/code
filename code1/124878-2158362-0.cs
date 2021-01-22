    var subset = from item in document.Descendants("Item")
                 where item.Element("Id").Value == itemId.ToString()
                 select new PurchaseItem()
                            {
                                Id = int.Parse(item.Element("Id").Value),
                                Name = item.Element("Name").Value,
                                Description = item.Element("Description").Value,
                                Price = int.Parse(item.Element("Price").Value)
                            };
