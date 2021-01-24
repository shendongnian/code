    public async Task<IActionResult> OnGetAsync1(int? id) 
    {
        return await _dbcontext.tbl1.ToListAsync();
    }
    public async Task<IActionResult> OnGetAsync2(int? id) 
    {
        return await _dbcontext.tbl2.ToListAsync();
    }
    ...
