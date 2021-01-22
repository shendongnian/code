    public IEnumerable <Country> ListPopulation()
    {
      IQueryable<Country> ids;
      foreach(var continent in Continents)
      {
        var ids = context.continentTable
                  .Where(y=>y.Name == continent.Name)
                  .Select(x=>x.countryId);
      }
    
      return GetPopulation(ids);
    }
