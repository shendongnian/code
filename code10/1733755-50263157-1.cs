    public class CategoryDto // or some other better name
    {
        public string Name { get; set; }
        // Choose the MINIMUM amount of properties that the client needs
    }
    // GET: api/Categories
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _context.Categories
            .Include(x => x.SubCategories) // this line you are missing
            .ToListAsync();
        return Ok(categories);
    }
