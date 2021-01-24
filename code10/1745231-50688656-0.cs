    private readonly proj.Data.ApplicationDbContext _context;
    
    private UserManager<Data.ApplicationUser> _userMannger;
    
    public IndexModel(proj.Data.ApplicationDbContext context, 
       UserManager<Data.ApplicationUser> user)
    {
       _userMannger= user;
        _context = context;
    }   
    public Models.Posts Posts { get; set; }
    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
    	var post = new Models.Posts {UserId = _userMannger.GetUserId(User), Text = Posts.Text };
    	_context.Posts.Add(post);
    	await _context.SaveChangesAsync();
    
    	return Page();
    }
