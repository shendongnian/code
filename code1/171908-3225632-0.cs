    PropertyInfo prop = buffer.GetType().GetProperty("NK");
    if (prop == null)
    {
        throw new Exception("prop is null!");
    }
    
    object value = prop.GetValue(buffer, null);
    if (value == null)
    {
        throw new Exception("value is null!");
    }
    
    string nk1 = value.ToString();
