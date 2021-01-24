    public Input0_ProcessInputRow(Input0Buffer Row)
            {
                Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();
                List<string> propertyList = new List<string>();
                Type myType = typeof(Input0Buffer);
                PropertyInfo[] allPropInfo = myType.GetProperties();
                List<PropertyInfo> SqlPropInfo = allPropInfo.Where(x => !x.Name.Contains("AM_")).ToList();
    
                // Loop through all the Sql Property Info so those without AM_
                for (int i = 0; i < SqlPropInfo.Count(); i++)
                {
                    List<string> group = new List<string>();
                    foreach (var propInfo in allPropInfo)
                    {
                        if (propInfo.Name.Contains(SqlPropInfo[i].Name))
                        {
                            // Group the values based on the property
                            // ex. All last names are grouped.
                            group.Add(propInfo.GetValue(Row, null).ToString());
                        }
                    }
    
                    // The Key is the Sql's Property Name.
                    list.Add(SqlPropInfo[i].Name, group);
                }
    
                foreach (var item in list)
                {
                    // Do a check if there are two values in both SQL and Oracle.
                    if (item.Value.Count >= 2)
                    {
                        if (item.Value.Count() != item.Value.Distinct().Count())
                        {
                            // Duplicates exist do nothing.
                        }
                        else
                        {
                            // The values are different so update the value[0]. which is the SQL Value.
                            UpdateRecord(item.Key, item.Value[0], Row.AssociateId);
                        }
                    }
                }
            }
