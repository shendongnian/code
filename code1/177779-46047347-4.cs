    private Dictionary<string, string> GetPropertiesValues(object item, Dictionary<string, string> headers)
    {
        Dictionary<string, string> values = new Dictionary<string, string>();
        if (item == null)
        {
            return values;
        }
        //We need to make sure each value is coordinated with the headers, empty string 
        foreach (var key in headers.Keys)
        {
            values[key] = String.Empty;
        }
        Type t = item.GetType();
        PropertyInfo[] propertiesInfo = t.GetProperties();
        foreach (PropertyInfo propertiyInfo in propertiesInfo)
        {
            //it not complex: string, int, bool, Enum
            if ((propertiyInfo.PropertyType.Module.ScopeName == "CommonLanguageRuntimeLibrary") || propertiyInfo.PropertyType.IsEnum)
            {
                if (headers.ContainsKey(propertiyInfo.Name))
                {
                    var value = propertiyInfo.GetValue(item, null);
                    if (value != null)
                    {
                        values[propertiyInfo.Name] = value.ToString();
                    }                         
                }
            }
            else//It's complex property
            {
                if (propertiyInfo.GetIndexParameters().Length == 0)
                {
                    Dictionary<string, string> lst = GetPropertiesValues(propertiyInfo.GetValue(item, null), headers);
                    foreach (var value in lst)
                    {
                        if (!string.IsNullOrEmpty(value.Value))
                        {
                            values[value.Key] = value.Value;
                        }
                    }
                }
            }
        }
        return values;
    }
