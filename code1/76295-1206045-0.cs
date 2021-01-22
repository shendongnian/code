    string test = "test string";
    Type type = test.GetType();
    PropertyInfo[] propInfos = type.GetProperties();
    for (int i = 0; i < propInfos.Length; i++) 
    {
        PropertyInfo pi = (PropertyInfo)propInfos.GetValue(i);
        string propName = pi.Name;
    }
