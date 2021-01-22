    Dictionary<Calc, List<PropertyValue>> result = 
        new Dictionary<Calc, List<PropertyValue>>();
    while (reader.Read())
    {
        // Work out calc
        List<PropertyValue> list;
        if (!result.TryGetValue(calc, out list))
        {
             list = new List<PropertyValue>();
             result[calc] = list;
        }
        list.Add(propValue);
    }
