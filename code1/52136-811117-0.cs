    public void FindClasses(object o)
    {
        if (o != null)
        {
            Type t = o.GetType();
            foreach(PropertyInfo pi in t.GetProperties())
            {
                if(!pi.PropertyType.IsValueType)
                {
                    // property is of a type that is not a value type (like int, double, etc).
                    FindClasses(pi.GetValue(o, null));
                }
            }
        }
    }
