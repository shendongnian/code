    public class SomeObject
    {
        public string CODE { get; set; }
        public string Name { get; set; }
    }
         public async Task<IEnumerable<SomeObject>> GetTest(string company)
    {
    
        var db = new SibaCiidDbContext();
        var results = (from o in db.Intermediary where o.CompanyCode == company select new SomeObject{CODE = o.CompanyCode, NAME = o.FullName });
    
        return await results.ToListAsync();
    }
   
