    public int Method(Bar bar, string propertyName)
    {
       var prop = typeof(Bar).GetProperty(propertyName);
       int value = (int)prop.GetValue(bar,null);
       return value * 2;
    }
