    /// Your result objects list
    List<DBObject> result = new List<DBObject>();
    System.Reflection.ConstructorInfo ci = objectType.GetConstructor(new Type[] { });
    System.Reflection.PropertyInfo[] props = objectType.GetProperties();
    if ((table != null) && (table.Rows.Count > 0) && (ci != null) && (props != null) && (props.Length > 0))
    {
    	for (int i = 0; i < table.Rows.Count; i++)
    	{
    		DBObject dob = (DBObject)ci.Invoke(new object[] { });
    		if (dob != null)
    		{
    			foreach (System.Reflection.PropertyInfo pi in props)
        		{
                    /// This is your method to get DB column name from config file
                    string dbColumnName = GetDBColumnFromMappingConfigFile(pi.Name);
                    object value = null;
                    if (table.Columns.Contains(dbColumnName))
    				{
    					if (table.Rows[i][dbColumnName] != DBNull.Value)
     				    {
    						value = table.Rows[i][dbColumnName];
    					}
        			}
                    if (value != null)
    				{
    				    if ((pi.PropertyType.IsGenericType) && (pi.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))))
    					{
    						Type t = pi.PropertyType.GetGenericArguments()[0];
    						if (t != null)
    						{
    							object val = Convert.ChangeType(value, t);
    							pi.SetValue(dob, val, null);
    						}
    					}
    					else
    					    pi.SetValue(dob, Convert.ChangeType(value, pi.PropertyType), null);
                    }
                }
            }
        }
    }
