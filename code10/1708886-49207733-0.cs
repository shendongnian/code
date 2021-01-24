    foreach (PropertyDescriptor prop in props)
    {
        var value = prop.GetValue(item);
        if(value is List<Tuple<string, string>> tupleList)
        {
            string tupleString = ConvertTupleListToString(tupleList);
            strBuilder.Append(tupleString);
        }
        else
        {
            strBuilder.Append(prop.Converter.ConvertToString(value));
        }
        strBuilder.Append(",");
    }
