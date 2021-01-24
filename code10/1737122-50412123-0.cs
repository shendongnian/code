    var userId = _caller.Claims.Single(c => c.Type == "id");
    var user = await _appDbContext.Users.Include(s =>s.Accounts).SingleAsync(c => c.Id == userId.Value);
    var accounts = user.Accounts.Select(a => new
            {
                a.AccountNumber,
                a.id
            });
    return new OkObjectResult(new
            {
                user.FirstName,
                user.LastName,
                accounts
            }); 
