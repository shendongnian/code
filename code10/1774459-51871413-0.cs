    if (columnDefs[i].IndexOf("Date") >= 0)
    {
        // Date search: we a parameter, not its value into the query
        subQuery += $" ({columnDefs[i]} = @prm_{columnDefs[i]}) and ";
    }
    
    ...
    
    // when executing the query
    using (var myQuery = new SqlQuery(subQuery, myConnection)) {
      // we set parameters' values
      for (int i = 0; i < columnDefs.Count(); ++i) {
        if (columnDefs[i].IndexOf("Date") >= 0) {
          //TODO: check the actual parameter value type (SqlDbType.DateTime?) 
          var prm = new SqlParameter($"@prm_{columnDefs[i]}", SqlDbType.DateTime);
          //TODO: check actual string format (d/M/yyyy?)
          prm.Value = DateTime.ParseExact(
             searchValues[i], 
            "d/M/yyyy", 
             CutureInfo.InvariantCulture);
    
          myQuery.Parameters.Add(prm);
        }
      }
    
      ...
    }
