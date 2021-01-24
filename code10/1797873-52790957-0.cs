    private ApplicationDbContext _context;
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    // this will get the userId of currently loggedIn user
    userId = User.Identity.GetUserId()
    // this line get all the address of loggedIn user from UserAddresses table
    _context.UserAddresses.Where(a => a.UserId == userId).ToList();
