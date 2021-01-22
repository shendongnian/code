    class Category
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> SubCategories { get; set; }
    }
    IEnumerable<Category> CategoryTreeStructure(XElement e)
    {
       var d = from t in e.Elements("category")
               select new Category()
               { 
                   ID = t.Attribute("id").Value, 
                   Name = t.Attribute("name").Value,
                   SubCategories = CategoryTreeStructure(t)
               };
       return d;
    }
