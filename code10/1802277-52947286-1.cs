    public class MyRootObject
    {
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
    public class Category
    {
        public string Name { get; set; }
        public bool Mandatory { get; set; }
    }
