    public void SaveValues(IEnumerable<KeyValuePair<int,bool>> values)
    {
        foreach(var pair in values)
        {
            int intVal = pair.Key;
            bool boolVal = pair.Value;
            // Do something here...
        }
    }
