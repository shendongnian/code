    public async Task<IEnumerable<Listing>> LoadAllUserListings(string userId)
    {
        var result = _context.Listing.Aggregate().Match(l => l.OwnerId == userId || l.Sales.Any(a => a.Owner.Id == userId)).
                Project(l => new Listing
                {
                    Id = l.Id,
                    Reference = l.Reference,
                    OwnerId = l.OwnerId,
                    Sales = l.Sales.Where(a => a.Owner.Id == userId || a.Manager.Id == userId),
                    Products = l.Products,
                    Status = l.Status,
                    DueDate = l.DueDate
                }).ToListAsync();
        return await result;
    } 
