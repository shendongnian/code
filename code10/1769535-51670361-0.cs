    using (var context = new DataContext())
    {
        using (var cmd = context.Database.GetDbConnection().CreateCommand())
        {
            cmd.CommandText = "exec uspGetOrgChart";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
            var personIdParam = cmd.CreateParameter();
            personIdParam.ParameterName = "ContactID";
            personIdParam.Value = id;
    
            cmd.Parameters.Add(personIdParam);
    
            context.Database.OpenConnection();
            using (var result = command.ExecuteReader())
            {
                if (result.HasRows)
                {
                    // do something with results
                }
            }
        }
    }
