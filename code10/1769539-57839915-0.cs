     using (var cmd = _db.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "dbo.GetCategories"; //sp name
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        _db.Database.OpenConnection();
                        using (var result = cmd.ExecuteReader())
                        {
                            if (result.HasRows)
                            {
                                 var List= MapToList<Category>(result);
                            }
                        }
                    }
    public IList<T> MapToList<T>(DbDataReader dr)
            {
                var objList = new List<T>();
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
                            if (colMapping.Any(a => a.Key.ToLower() == prop.Name.ToLower()))
                            {
                                var val = dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                                prop.SetValue(obj, val == DBNull.Value ? null : val);
                            }
                        }
                        objList.Add(obj);
                    }
                }
                return objList;
            }
