c#
var connectionstring = "Connection string";
var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionsBuilder.UseSqlServer(connectionstring);
ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options);
// Or you can instantiate inside using
using(ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options))
{
   //...do stuff
}
