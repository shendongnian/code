    public SqlParameter GetTableValuedParameter<Model>(List<Model> valueTable, string typeName, string paramName)
            {
                if(valueTable == null || valueTable.Count == 0)
                    throw new Exception("Cant be empty or null.");
    
                DataTable dataTable = new DataTable();
    
                var header = valueTable.First().GetType().GetProperties();
    
                foreach (var propertyInfo in header)
                {
                    dataTable.Columns.Add(propertyInfo.Name);
                }
    
                foreach (var model in valueTable)
                {
                    DataRow dataRow = dataTable.NewRow();
                    var properties = model.GetType().GetProperties();
                    foreach (var propertyInfo in properties)
                    {
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(model);
                    }
    
                    dataTable.Rows.Add(dataRow);
                }
    
                var sqlParameter = new SqlParameter(paramName, SqlDbType.Structured);
                sqlParameter.Value = dataTable;
                sqlParameter.TypeName = typeName;
    
                return sqlParameter;
            }
