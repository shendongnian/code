    public class Featured
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string short_description { get; set; }
        public double rating_avg { get; set; }
        public string image { get; set; }
    }
    
    public class CategoryMedia
    {
        public int position { get; set; }
        public int category_id { get; set; }
        public int media_id { get; set; }
        public int id { get; set; }
    }
    
    public class Medium
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string short_description { get; set; }
        public double rating_avg { get; set; }
        public string image { get; set; }
        public CategoryMedia category_media { get; set; }
    }
    
    public class Category
    {
        public int id { get; set; }
        public string title { get; set; }
        public object description { get; set; }
        public int position { get; set; }
        public List<Medium> media { get; set; }
    }
    
    public class RootObject
    {
        public Featured featured { get; set; }
        public List<Category> categories { get; set; }
    }
