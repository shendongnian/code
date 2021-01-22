    public static class ccExtensions
    {
        public static IEnumerable<string> Categories(this XElement item,
                                                     string type)
        {
            return from category in item.Elements("category")
                   where (string) category.Attribute("domain") == type
                         && !string.IsNullOrEmpty(category.Value)
                   select category.Value;
        }
    }
