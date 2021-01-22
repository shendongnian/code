            public static List<T> ConvertDataTable<T>(DataTable dt)
            {
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                return data;
            }
            private static T GetItem<T>(DataRow dr)
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
    
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                       //in case you have a enum/GUID datatype in your model
                       //We will check field's dataType, and convert the value in it.
                        if (pro.Name == column.ColumnName){                
                        try
                        {
                            var convertedValue = GetValueByDataType(pro.PropertyType, dr[column.ColumnName]);
                            pro.SetValue(obj, convertedValue, null);
                        }
                        catch (Exception e)
                        {         
                           //ex handle code                   
                            throw;
                        }
                            //pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                        else
                            continue;
                    }
                }
                return obj;
            }
