    public static OutType CreateInstance<OutType>(string s)
    {
        Type t;
        if (s.StartsWith("abcdef"))
        {
            t = typeof(Bar);
            return System.Activator.CreateInstance(t) as OutType;
        }
        else
        {
            t = typeof(Meh);
            return System.Activator.CreateInstance(t) as OutType;
        }
    }
