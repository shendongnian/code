    Dictionary<Guid, List<PropertyValue>> result = 
        new Dictionary<Guid, List<PropertyValue>>();
    while (reader.Read())
    {
        // Work out calc
        List<PropertyValue> list;
        if (!result.TryGetValue(calc.InnerID, out list))
        {
             list = new List<PropertyValue>();
             result[calc.InnerID] = list;
        }
        list.Add(propValue);
    }
