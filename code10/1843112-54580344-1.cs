    Dictionary<string, object> pars = new Dictionary<string, object>();
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < idParameterList.Count; i++)
         pars.Add($"@Id{i}", idParameterList[i]);
    sb.Append(String.Join(",", pars.Keys.ToArray()));
     dbContext.Database.ExecuteSqlCommand(sb.ToString(), pars.Values.ToArray()).ToList();
