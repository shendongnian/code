    // DbContext.
    private readonly ApplicationDbContext _context;
    
    public HomeController()
    {
       _context = new ApplicationDbContext();
    }
