    public class Person1
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Person2
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MyContext : DbContext
    {
        public MyContext() : base ("Data Source=MI-KOMPUTER\\SQLEXPRESS;Integrated security=true;Initial catalog=justTest") { }
        public DbSet<Person1> Person1 { get; set; }
        public DbSet<Person2> Person2 { get; set; }
    }
