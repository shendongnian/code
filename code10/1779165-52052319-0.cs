    static void Main()
    {
        using (MyDbContext ctx = new MyDbContext())
        {
            // Build a new object
            MyClass o = new MyClass() { Id = 1, ChildObject = null };
            
            // Add it to your Context (It's not in the DB yet!)
            ctx.MyObjects.Add(o);
            // Write all changes (the new object) to the Db
            ctx.SaveChanges();
        }
    }
    // You got some DbContext with a DbSet pointing to your Table "MyTable"
    public class MyDbContext : DbContext
    {
        public DbSet<MyClass> MyObjects { get; set; }
    }
    // You've got a class to map your table to some nice object.
    [Table("MyTable")]
    public class MyClass
    {
        // Some column..
        [Key]
        public int Id { get; set; }
        // And some ForeignKey! Which maps a column with the Id to an object.
        [ForeignKey("ChildObjectId")]
        public MyClass ChildObject { get; set; }
    }
