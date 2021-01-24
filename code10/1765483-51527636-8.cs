        //call extension like this:
        _context.QueryStoredProcedureAsync<YourViewModel>("YourProcedureName", ("a", 1), ("b", 2), ("c", 3));
        //here is extension
        public static class ContextExtensions
        {
        public static async Task<List<T>> QueryStoredProcedureAsync<T>(
            this DbContext context, 
            string storedProcName, 
            params (string Key, string Value)[] args)//<==c# 7 new feature
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = storedProcName;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (var arg in args)
                {
                    var param = command.CreateParameter();
                    param.ParameterName = arg.Key;
                    param.Value = arg.Value;
                    command.Parameters.Add(param);
                }
                using (var reader = await command.ExecuteReaderAsync())
                {
                    return reader.MapToList<T>();
                }
            }
        }
        private static List<T> MapToList<T>(this DbDataReader dr)
        {
            var result = new List<T>();
            var props = typeof(T).GetRuntimeProperties();
            var colMapping = dr.GetColumnSchema()
                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                .ToDictionary(key => key.ColumnName.ToLower());
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        var val =
                            dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                        prop.SetValue(obj, val == DBNull.Value ? null : val);
                    }
                    result.Add(obj);
                }
            }
            return result;
        }
        }
