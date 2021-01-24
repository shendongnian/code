    public List<BlogViewModel> Blogs { get; set; }
    public async Task OnGetAsync()
    {
         Blogs = await _context.Blog
                .Select(b => new BlogViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,                           
                    OwnerName = b.Owner.UserName,
                })
                .ToListAsync();
    }
