    public static void AddPropertyToObject(ExpandoObject o, string propertyName, object propertyValue)
    {
        IDictionary<string, object> d = o as IDictionary<string, object>;
        if (d == null) return;
        if (!d.ContainsKey(propertyName))
        {
                    d.Add(propertyName, propertyValue);
                }
                else
                {
                    d[propertyName] = propertyValue;
                }
            }
