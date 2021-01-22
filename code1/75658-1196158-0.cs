    public static object GetProperty(this object o, Type t, string p)
    {
        if (o != null)
        {
            PropertyInfo pi = t.GetProperty(p);
            if (pi != null)
            {
                return pi.GetValue(o, null);
            }
            return null;
        }
        return null;
    }
