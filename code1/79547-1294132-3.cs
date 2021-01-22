    private List<Items> GetCategories(XElement element)
            {
    
                return (from category in element.Elements("control")
                        select new Items()
                        {
                            Parent = element.Attribute("name").Value,
                            Name = category.Attribute("name").Value,
                            SubCategories = this.GetCategories(category),
                            IsLeaf = category.Attribute("attribute").Value
    
                        }).ToList();
            }
