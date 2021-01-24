    //Firstly: IEnumerable<> should be List<>, because you need to massage result later
    public IEnumerable<AllConditionByCountry> GenerateConditions(int paramCountryId)
    {
        var AllConditionsByCountry =
                (from cd in db.tblConditionDescriptions...
                 join...
                 join...
                 select new AllConditionByCountry
                 {
                     CountryID = cd.CountryID,
                     ConditionDescription = cd.ConditionDescription,
                     ConditionID = cd.ConditionID,
                 ...
                 ...
                })
                .OrderBy(x => x.CountryID)
                .ToList() //return a list, so only 1 query is executed
                //.AsEnumerable<AllConditionByCountry>();//it's useless code, anyway.
    
        return AllConditionsByCountry;
    }
