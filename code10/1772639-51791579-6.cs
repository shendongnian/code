     public async Task<IEnumerable<Intermediary>> GetTest(string company)
    {
    
        var db = new SibaCiidDbContext();
        var results = (from o in db.Intermediary where o.CompanyCode == company select o);
    
        return await results.ToListAsync();
    }
   
