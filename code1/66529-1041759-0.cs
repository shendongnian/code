      //construct a query to fetch the row/column shaped results.
    var query = 
      from m in db.map
      //where m.... ?
      from a in m.Agency
      from b in m.BusinessUnit
      from c in m.Client
      // where something about a or b or c ?
      select new {
        AgencyID = a.AgencyID,
        BusinessUnitID = b.BusinessUnitID,
        ClientID = c.ClientID,
        NumberOfAccounts = c.NumberOfAccounts,
        Score = c.Score
      };
      //hit the database
    var rawRecords = query.ToList();
      //shape the results further into a hierarchy.    
    List<Agency> results = rawRecords
      .GroupBy(x => x.AgencyID)
      .Select(g => new Agency()
      {
        BusinessUnits = g
        .GroupBy(y => y.BusinessUnitID)
        .Select(g2 => new BusinessUnit()
        {
          Clients = g2
          .Select(z => new Client()
          {
            NumberOfAccounts = z.NumberOfAccounts,
            Score = z.Score
          })
        })
      })
      .ToList();
