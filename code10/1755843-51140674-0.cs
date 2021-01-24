    [XmlRoot("categories")] // <--
    public class CategoriesViewModel
    {
        public CategoriesViewModel()
        {
            _categories = new List<Category>();
        }
        private List<Category> _categories;
        [XmlElement("category")] // <--
        public List<Category> Categories
        {
            get { return _categories; }
            set { value = _categories; }
        }
        public class Category
        {
            [XmlElement("id")] // <--
            public int Id { get; set; }
            [XmlElement("name")] // <--
            public string Name { get; set; }
        }
    }
