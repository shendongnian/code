    public  IList<IRegion> GetRegionList(string countryCode)
    {
        var query = 
            from region in Database.RegionDataSource
            where region.CountryCode == countryCode
            orderby region.Name
            select region; 
    
         return query.ToList(); 
    }
