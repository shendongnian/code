    var rawQuery = new StringBuilder("SELECT * FROM ItemsTable WHERE ");
    var sqlParameters = new List<SqlParameter>();
    foreach (var f in FilterList) {
      var parameterName = $"@p{FilterList.IndexOf(f)}";
      var parameterizedCondition = string.Format(f.condition, parameterName);
      // f.condition is something like "Name LIKE {0}"
      rawQuery.Append(parameterizedCondition);
      sqlParameters.Add(new SqlParameter(parameterName, f.userInput));
    }
    
    var filteredItems = context.ItemsTable
      .FromSql(rawQuery.ToString(), sqlParameters)
      .ToList();
