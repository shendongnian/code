    List<SqlCeParameter> parameters = new List<SqlCeParameter>();
            
    parameters.Add(new SqlCeParameter("@Username", NewUsername));
    parameters.Add(new SqlCeParameter("@Password", Password));
            
    cmd.Parameters.AddRange(parameters.ToArray());
