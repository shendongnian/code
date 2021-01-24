c#
var connectionstring = "Connection string";
var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionsBuilder.UseSqlServer(connectionstring);
using(ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options))
{
   //...do stuff
}
