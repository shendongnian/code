public class HomeController : Controller
{
	private readonly FooIdentityDbContext_dbContext;
	public HomeController(FooIdentityDbContext dbContext)
	{
		_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
	}
	
	public async Task<IActionResult> UserList(string roleName, bool fooBool, string firstName)
	{
		// You are interested in Users on Roles, so it's easier to start on the UserRoles table
		var usersInRole = _dbContext.UserRoles.Select(userRole => userRole);
		// filter only users on role first
		if (!string.IsNullOrWhiteSpace(roleName))
		{
			usersInRole = usersInRole.Where(ur => ur.Role.Name == roleName);
		}
		// then filter by fooBool
		usersInRole = usersInRole.Where(ur => ur.User.FooBool == fooBool);
		// then filter by user firstname or whatever field you need
		if (!string.IsNullOrWhiteSpace(firstName))
		{
			usersInRole = usersInRole.Where(ur => ur.User.FirstName.StartsWith(firstName));
		}
		// finally materialize the query, sorting by FirstName ascending
		// It's a common good practice to not return your entities and select only what's necessary for the view.
		var filteredUsers = await usersInRole.Select(ur => new UserListViewModel
		{
			Id = ur.UserId,
			Email = ur.User.Email,
			FooBool = ur.User.FooBool,
			FirstName = ur.User.FirstName
		}).OrderBy(u => u.FirstName).ToListAsync();
		return View("UserListNew", filteredUsers);
	}
}
**Bonus**: I've been reading the [EF Core in Action](https://www.manning.com/books/entity-framework-core-in-action) book by Jon Smith and it's great. I highly recommend reading it if you want to keep using EF Core in your projects. It's full of nice tips and real world examples. 
