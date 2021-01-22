    // this isn't anonymous, and should cast
    public class MyRegion : IRegion {
        public string RegionCode {get;set;}
        public string RegionName {get;set;}
    }
    
    public  IList<IRegion> GetRegionList(string countryCode)
    {
        var query = from c in Database.RegionDataSource
                    where (c.CountryCode == countryCode)
                    orderby c.Name
                   select new MyRegion {RegionCode = c.RegionCode, RegionName = c.RegionName}; 
    
         return query.Cast<IRegion>().ToList(); 
    }
