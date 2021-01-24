     private void PopulateCombobox(object column)
            {
                comboBox1.DataSource = null;
                BindingSource data = dataGridView.DataSource as BindingSource;
                DataGridViewColumn col = column as DataGridViewColumn;
                ArrayList list = new ArrayList(data.Count);
                
                // Retrieve each value and add it to the ArrayList if it isn't
                // already present. 
                foreach (Object item in data)
                {
                    Object value = null;
    
                        PropertyInfo[] properties = item.GetType().GetProperties(
                            BindingFlags.Public | BindingFlags.Instance);
                        foreach (PropertyInfo property in properties)
                        {
                            if (String.Compare(col.DataPropertyName,
                                    property.Name, true /*case insensitive*/,
                                    System.Globalization.CultureInfo.InvariantCulture) == 0)
                            {
                                value = property.GetValue(item, null /*property index*/);
                                break;
                            }
                            else if(property.PropertyType==typeof(Address)|| property.PropertyType == typeof(Contact) /*||property.PropertyType==typeof(Geo)*/)
                            {
                                string propname = col.DataPropertyName.Substring(col.DataPropertyName.IndexOf('.') + 1);
                                if (string.Compare(col.DataPropertyName, property.Name + '.' + propname, true,
                                        System.Globalization.CultureInfo.InvariantCulture) == 0)
                                {
                                    object obj = property.GetValue(item, null);
                                    Type propType = obj.GetType();
                                    PropertyInfo pinf = propType.GetProperty(propname);
                                    value = pinf.GetValue(obj, null) == null
                                        ? string.Empty
                                        : pinf.GetValue(obj, null).ToString();
                                }
                            }
                        
    
                    }
    
                    // Skip empty values, but note that they are present. 
                    if (value == null || value == DBNull.Value)
                    {
    
                        continue;
                    }
    
                    // Add values to the ArrayList if they are not already there.
                    if (!list.Contains(value))
                    {
                        list.Add(value);
                    }
                }
                comboBox1.DataSource = list;
            }
