    public class Category
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public List<SubCategory> SubCategory {get; set;}
    }
    public class SubCategory
    {
        public int Id {get; set;}
        public string Parent {get; set;}
        public string Name {get; set;}
    }
