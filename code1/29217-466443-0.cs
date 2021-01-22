    DataLoadOptions dlo = new DataLoadOptions();
    //bring in the Regions for each Country
    dlo.LoadWith<ec_Country>(c => c.Regions);
    //bring in the localizations
    dlo.AssociateWith<ec_Country>(c => c.Localizations
      .Where(loc => loc.StatusID == 4 && loc.WebSiteID == this.webSiteID)
    );
    dlo.AssociateWith<ec_Region>(r => r.Localizations);
    
    //set up the dataloadoptions to eagerly load the above.
    dataContext.DataLoadOptions = dlo;
    
    //Pull countries and all eagerly loaded data into memory.
    List<ec_Country> queryResult = query.ToList();
    
    //further map these data types to business types
    List<Country> result = queryResult
      .Select(c => ToCountry(c))
      .ToList();
----------
    
    public Country ToCountry(ec_Country c)
    {
      return new Country()
      {
        Name = c.Name,
        Text = c.Localizations.Single().Text,
        Regions = c.Regions().Select(r => ToRegion(r)).ToList()
      }
    }
    
    public Region ToRegion(ec_Region r)
    {
      return new Region()
      {
        Name = r.Name,
        Text = r.Localizations.Single().Text,
        Cities = r.Cities.Select(city => ToCity(city)).ToLazyList();
      }
    }
