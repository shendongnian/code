    // It's quite possible that the following line should be change.
    // You should replace DbContext with your corresponding class. 
    var db = new DbContext();
    using(var connection = db.DataBase.Connection)
    {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "EXEC your stored procedure name";
    
        using (var reader = command.ExecuteReader())
        {
            var total = reader.GetInt32(0);
    
            reader.NextResult();
    
            var continentByPercentage =((IObjectContextAdapter) db)
                                .ObjectContext
                                .Translate<ContinentByPercentage>(reader)
                                .ToList();
    
            reader.NextResult();
    
            var countrybyMembers =
                            ((IObjectContextAdapter) db)
                                .ObjectContext
                                .Translate<CountryByMembers>(reader)
                                .ToList();
            return new MemberStatsByTopCountryViewModel
            {
                total = total,
                continentByPercentage = continentByPercentage ,
                countrybyMembers = countrybyMembers 
            };
        }
    }
