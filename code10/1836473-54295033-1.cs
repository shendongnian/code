    public static IEnumerable<dynamic>( /* params */)
    {
       // build command object here.
    
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())  // read the first one to get the columns collection
            {
              var cols = reader.GetSchemaTable()
                           .Rows
                           .OfType<DataRow>()
                           .Select(r => r["ColumnName"]);
              do
              {
                dynamic t = new System.Dynamic.ExpandoObject();
                foreach (string col in cols)
                {
                  ((IDictionary<System.String, System.Object>)t)[col] = reader[col];
                }
                yield return t;
              } while (reader.Read());
            }
          }
       // remember to close connection
    }
