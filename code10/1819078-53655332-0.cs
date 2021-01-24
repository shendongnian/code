    foreach (DataRow dr in dt_MappedColumns.Rows)
    {
        string key = dr["TColumnName"].ToString();
        string value = dr["AColumnName"].ToString();
        if (!dictionary1.ContainsKey(key))
        {
            // key does not already exist, so add it
            dictionary1.Add(key, value);
        }
        else
        {
            // key exists, get the existing value
            object existingValue = dictionary1[key];
            if (existingValue is string)
            {
                // replace the existing string value with a list
                dictionary1[key] = new List<string> { (string)existingValue, value }; 
            }
            else
            {
                // the existing value is a list, so add the new value to it
                ((List<string>)existingValue).Add(value);
            }
        }
    }
