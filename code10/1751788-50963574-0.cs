    public class Category
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Media> Media { get; set; }
    }
    
    public class Media
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
    }
    public class Featured
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Short_Description { get; set; }
    }
