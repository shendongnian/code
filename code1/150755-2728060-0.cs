    public  IList<IRegion> GetRegionList(string countryCode)
    {
        var query = from c in Database.RegionDataSource
                    where (c.CountryCode == countryCode)
                    orderby c.Name
                    select new Region() 
                        {
                            RegionCode = c.RegionCode, 
                            RegionName = c.RegionName
                        }; 
    
         return query.ToList(); 
    }
