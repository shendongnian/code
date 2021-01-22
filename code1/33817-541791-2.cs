        public static string CategoryValue(this XElement item, string type)
        {
            var category = item.Descendants("category").First(c => (string)c.Attribute("type") == type);
            return category == null ? null : category.Value;
    
        }
