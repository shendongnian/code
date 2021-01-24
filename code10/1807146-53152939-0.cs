    using System.Data.Entity;
    namespace EntityFrameWorkMissingTableTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var context = new MyContext("Data Source=localhost;Initial Catalog=MyContext;Integrated Security=True");
            }
        }
        public class MyContext : DbContext
        {
            public MyContext(string connectionString)
                :base(connectionString)
            {
            }
            DbSet<Entity> Entities { get; set; }
        }
        public class Entity
        {
            public int Id { get; set; }
        }
    }
