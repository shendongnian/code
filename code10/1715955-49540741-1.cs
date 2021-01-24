    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
    	public ApplicationDbContext CreateDbContext(string[] args)
    	{
    		var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
    		builder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=yourdatabase;User ID=user;Password=password;TrustServerCertificate=True;Trusted_Connection=False;Connection Timeout=30;Integrated Security=False;Persist Security Info=False;Encrypt=True;MultipleActiveResultSets=True;",
    			optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name));
    
    		return new ApplicationDbContext(builder.Options);
    	}
    }
