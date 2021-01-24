        using System.Data.Entity;
    namespace EntityFrameWorkMissingTableTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var context = new MyContext("Data Source=localhost;Initial Catalog=MyContext;Integrated Security=True"))
                {
                    context.Entities.Add(new Entity());
                    context.SaveChanges();
                }
            }
            public class MyContext : DbContext
            {
                public MyContext(string connectionString)
                    : base(connectionString)
                {
                }
                public DbSet<Entity> Entities { get; set; }
            }
            public class Entity
            {
                public int Id { get; set; }
            }
        }
    }
