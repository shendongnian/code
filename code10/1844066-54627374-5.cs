    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ... // other properties
        // every Category has zero or more Todos (one-to-many)
        public virtual ICollection<Todo> Todos  { get; set; }
    }
    public class Todo
    {
        public int Id { get; set; }
        public string Content { get; set; }
        ... // other properties
        // every Todo belongs to exactly one Category, using foreign key
        public int CategoryId { get; set }
        public virtual Category Category { get; set; }
        // every Category has zero or more Infos:
        public virtual ICollection<Info> Infos { get; set; }
    }
