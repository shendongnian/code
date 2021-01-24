        foreach (PropertyInfo pro in temp.GetProperties())
                        {
                            if(pro.PropertyType.IsClass && pro.PropertyType == typeof(Category))
                            {
                                  Category subObj = Activator.CreateInstance<Category>();
                                  foreach (PropertyInfo propertyin subObj.GetProperties())
                                  {      
                                       property.SetValue(subObj , dr[property.Name], null);
                                  }
                                  pro.SetValue(obj, subObj , null);
                            }
                            if (pro.Name == column.ColumnName)
                            {
                                pro.SetValue(obj, dr[column.ColumnName], null);
                            }
                            else
                            {
                                continue;
                            }
                        }
