    // Some sql statement with a placeholder for all parameters (@ID0, @ID1, @ID2, ...)
    string sql = "select * from table where ID in ( {0} )";
    // Create a list of items of @ID0, 3; @ID1, 8; ...
    var parameters = myList.Where(item => item.MatchesSomeCondition())
                           .Select((item, index) => new
                                   {
                                       Name = "@ID" + index,
                                       Value = item.ID
                                   });
    // Add all parameters to the sqlCmd
    foreach(parameter in parameters)
    {
        sqlCmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
    }
    // Insert all @IDx into the sql statement
    // Result: "select * from table where ID in ( @ID0, @ID1, @ID2, ... )"
    sqlCmd.CommandText = String.Format(sql, String.Join(", ", parameters.Select(parameter => parameter.Name).ToArray()
