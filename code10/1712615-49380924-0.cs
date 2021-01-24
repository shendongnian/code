    static string Data(string tableName, string columnNames, string orderBy)
    {
      var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(i => i.Name == tableName);
      using (var context = new BloggingEntities())
      {
        var data = Select(type, columnNames, orderBy, context);
        var str = JsonConvert.SerializeObject(data);
        return str;
      }
    }
    
    static string Select(Type type, string columnNames, string orderBy, BloggingEntities _dbContext)
    {
      var data = _dbContext.Set(type).AsNoTracking().AsQueryable();
      var selectStatement = "new ( " + columnNames + ")";
      var filtered = data.Select(selectStatement).OrderBy(orderBy);
      return JsonConvert.SerializeObject(filtered);
    }
