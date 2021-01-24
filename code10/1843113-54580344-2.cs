    Dictionary<string, object> pars = new Dictionary<string, object>();
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < idParameterList.Count; i++)
         pars.Add($"@Id{i}", idParameterList[i]);
    sb.Append(String.Join(",", pars.Keys.ToArray()));
    
    var finalQuery = strQuery + sb.ToString() + ");";
     dbContext.Database.ExecuteSqlCommand(finalQuery , pars.Values.ToArray()).ToList();
