    public class Category
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public List<string> SubCategory {get; set;}
    }
    public class SubCategory
    {
        public int Id {get; set;}
        public string Parent {get; set;}
        public string Name {get; set;}
    }
