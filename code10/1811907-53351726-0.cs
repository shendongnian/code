    public class AppDbContext : DbContext
    {
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var coonectionString = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=AppDb01;Integrated Security=True";
            optionsBuilder.UseSqlServer(coonectionString);
        }
    }
