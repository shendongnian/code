    using (_context)
    {
    using (var cmd = _context.Database.GetDbConnection().CreateCommand())
    {
    cmd.CommandText = "exec uspGetOrgChart";
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
    var personIdParam = cmd.CreateParameter();
    personIdParam.ParameterName = "ContactID";
    personIdParam.Value = id;
    
    cmd.Parameters.Add(personIdParam);
    
    _context.Database.OpenConnection();
    using (var result = cmd.ExecuteReader())
    {
    if (result.HasRows)
    {
    // do something with results
                                
    }
    }
    }
                    
    }
