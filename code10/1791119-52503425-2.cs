    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GuestUser userToInsert)
    {
        // All checks and validation ...
    
        // You can get the current user ID from the user claim for instance
        int currentUserId = int.Parse(User.FindFirst(Claims.UserId).Value);
    
        // _context is your ApplicationDbContext injected via controller constructor DI 
        userToInsert.HostUserId = currentUserId;
    
        // Save new guest user associated with the current host user
        _context.GuestUsers.Add(userToInsert);
        await _context.SaveChangesAsync();
    
        // If you need to get the current user with all guests
        List<HostUser> currentUser = await _context.Users.Include(host => host.GuestUsers).ToListAsync();
    
        return Ok(currentUser);
    }
