    public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
            {
                public DBContext CreateDbContext(string[] args)
                {
                    var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
        
                    // Row numbers for paging adds support for old SQL server 2005+. See more: 
                    // https://docs.microsoft.com/en-us/ef/core/api/microsoft.entityframeworkcore.infrastructure.sqlserverdbcontextoptionsbuilder
                    optionsBuilder.UseSqlServer("Server=localhost;Database=DatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=SSPI", x => x.UseRowNumberForPaging());
                    
                    return new DBContext(optionsBuilder.Options);
                }
            }
