    public static List<T> Convert<T>(IDataReader dr) where T : class, new()
    {
        List<T> list = new List<T>();
        T obj = default(T);
        while (dr.Read()) {
            obj = Activator.CreateInstance<T>();
            foreach (PropertyInfo prop in obj.GetType().GetProperties()) {
                if (!object.Equals(dr[prop.Name], DBNull.Value)) {
                    prop.SetValue(obj, dr[prop.Name], null);
                }
            }
            list.Add(obj);
        }
        return list;
    }
    
    
    using (var conn = new SqlConnection(_dbContextProvider.DbContext.Database.Connection.ConnectionString))
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(@"[dbo].[GetOutput]", conn);
        cmd.CommandTimeout = 60;
        cmd.CommandType = CommandType.StoredProcedure;
        
        foreach (var item in list)
        {
            cmd.Parameters.Add(item);
        }
    
        using ( var reader = cmd.ExecuteReader() ){
        List<Entity> result = Convert<Entity>(reader); // convert to entity.
        cmd.Connection.Close(); 
        }
    }
