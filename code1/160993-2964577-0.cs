    public static string ToQuery(this SqlCommand command)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("exec ");
      sb.Append(command.CommandText);
    
      List<string> parameters = new List<string>();
    
      for (int i=0; i<command.Parameters.Count;i++)
      {
        if (command.Parameters[i].Direction != ParameterDirection.ReturnValue)
        {
          parameters.Add(string.Format(" {0}={1}", command.Parameters[i].ParameterName, command.Parameters[i].Value));
        }
      }
    
      if (parameters.Count > 0) sb.Append(string.Join(",", parameters.ToArray()));
    
      return sb.ToString();
    }
