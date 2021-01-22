    Type t = bfa.GetType();
    PropertyInfo[] properties = t.GetProperties();
    foreach(var prop in properties)
    {
        Debug.WriteLine(string.Format("{0}: {1}", prop.Name,prop.GetValue(bfa,null)));
    }
