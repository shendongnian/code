      public class Category
      {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }
      }
    
      public class Filter
      {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }
      }
    
      public class Menu
      {
        public int Id { get; set; }
        public string Name { get; set; }
        public MenuType MenuType { get; set; }
        public int? CategoryId { get; set; }
        public int? FilterId { get; set; }
    
        public Category Category { get; set; }
        public Filter Filter { get; set; }
      }
