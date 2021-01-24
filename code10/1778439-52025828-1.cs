        foreach (PropertyInfo pro in temp.GetProperties())
                        {
                            if(pro.PropertyType.IsClass && pro.PropertyType == typeof(Category))
                            {
                                  Category subObj = Activator.CreateInstance<Category>();
                                  foreach (PropertyInfo propertyin subObj.GetProperties())
                                  {     
                                        if (dr[property.Name] != DBNull.Value) 
                                             property.SetValue(subObj , dr[property.Name], null);
                                  }
                                  pro.SetValue(obj, subObj , null);
                            }
                            if (pro.Name == column.ColumnName)
                            {
                                 if (dr[pro.Name] != DBNull.Value) 
                                      pro.SetValue(obj, dr[column.ColumnName], null);
                            }
                            else
                            {
                                continue;
                            }
                        }
