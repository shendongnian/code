    public static SqlCommand AddParameter<T>(this SqlCommand command, string name, IEnumerable<T> ids)
    {
      var parameter = command.CreateParameter();      
    
      parameter.ParameterName = name;
      parameter.TypeName = typeof(T).Name.ToLowerInvariant() + "_id_list";
      parameter.SqlDbType = SqlDbType.Structured;
      parameter.Direction = ParameterDirection.Input;
    
      parameter.Value = CreateIdList(ids);
    
      command.Parameters.Add(parameter);
      return command;
    }
    
    private static DataTable CreateIdList<T>(IEnumerable<T> ids)
    {
      var table = new DataTable();
      table.Columns.Add("id", typeof (T));
    
      foreach (var id in ids)
      {
    	table.Rows.Add(id);
      }
    
      return table;
    }
