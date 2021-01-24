    namespace ExampleWebAppilcationTest
    {
    public class ExampleDB : DbContext
    {
        public ExampleDB() : base(nameOrConnectionString: "Your Database Connection String") { }
        public DbSet<TableData> TData { get; set; }
    }
    }
    
    
    
    namespace ExampleWebAppilcationTest
    {
    public class TableData
    {
        [Key]
        public String Tag { get; set; }
        public String Server { get; set; }
        public double Frequency { get; set; }
    }
    }
