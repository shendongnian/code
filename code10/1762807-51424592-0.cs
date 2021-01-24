    foreach (PropertyInfo propertyinfo in typeof(yourClass).GetProperties())
                {
                    if (propertyinfo != null && !string.IsNullOrEmpty(propertyinfo.Name) && propertyinfo.GetValue(yourobject) != null)
                    {
                        var fieldname = propertyinfo.Name;
                        var valueOfField=propertyinfo.GetValue(yourobject);
                    }
                }
