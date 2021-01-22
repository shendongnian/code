    public class Category
    {
        public Category()
        {
            this.ChildCategories = new List<Category>();
        }
        public string Name { get; set; }
        public IList<Category> ChildCategories { get; private set; }
    }
