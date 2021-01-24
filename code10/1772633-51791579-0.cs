     public async Task<IEnumerable<Intermediary>> GetTest(string company)
{
    var db = new SibaCiidDbContext();
    var results = (from o in db.Intermediary where o.CompanyCode == company select o).Select(o => new {
        CODE = o.CompanyCode,
        NAME = o.FullName
    });
    return await results.ToListAsync();
