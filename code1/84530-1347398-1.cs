    public void Print(object value, int depth)
    {
        foreach(var property in value.GetType().GetProperties())
        {
            var subValue = property.GetValue(value);
            if(subValue is IsEnumerable)
            {
                 PrintArray(property, (IEnumerable)subValue);
            }
            else
            {
                 PrintProperty(property, subValue);
            }         
        }
    }
