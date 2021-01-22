    using System.Reflection;
    public static ChildClass Clone(BaseClass b)
    {
        ChildClass p = new ChildClass(...);
        // Getting properties of base class
        PropertyInfo[] properties = typeof(BaseClass).GetProperties();
        // Copy all properties to parent class
        foreach (PropertyInfo pi in properties)
        {
            if (pi.CanWrite)
                pi.SetValue(p, pi.GetValue(b, null), null);
        }
        return p;
    }
