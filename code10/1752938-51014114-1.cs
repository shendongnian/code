    // async modifier not needed here
    public Task<Basket> GetUserBasketAsync(IdentityUser identityUser)
    {
        //Include method returns related Entity. 
        return context.Basket
            .Include(x => x.IdentityUser)
            .Where(x => x.IdentityUser.Id == identityUser.Id)
            // use the asynchronous version instead of the synchronous one
            .SingleOrDefaultAsync();
    }
