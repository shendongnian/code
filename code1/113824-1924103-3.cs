    var cat = from c in doc.Descendants("category")
              where c.Attribute("text").Value == "Business News"
              let node = c.Parent ?? c
              select c.Parent == null
                         ? c // Parent null, just return child
                         : new XElement(
                               "category",
                               c.Parent.Attributes(), // Copy the attributes
                               c                      // Add single child
                               );
