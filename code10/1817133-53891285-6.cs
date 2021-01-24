    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [TypeConverter(typeof(CategoryConverter))]
        public Category Category { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
<!---->
    public class CategoryService
    {
        List<Category> list = new List<Category>{
            new Category() { Id = 1, Name = "Category 1" },
            new Category() { Id = 2, Name = "Category 2" },
            new Category() { Id = 3, Name = "Category 3" },
        };
        public IEnumerable<Category> GetAll()
        {
            return list;
        }
    }
