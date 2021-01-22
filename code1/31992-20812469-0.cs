    public static string ToStringNullSafe(this object obj)
    {
        return obj != null ? obj.ToString() : String.Empty;
    }
    public static bool Compare<T>(T a, T b, params string[] ignore)
    {
        var aProps = a.GetType().GetProperties();
        var bProps = b.GetType().GetProperties();
        int count = aProps.Count();
        string aa, bb;
        for (int i = 0; i < count; i++)
        {
            aa = aProps[i].GetValue(a, null).ToStringNullSafe();
            bb = bProps[i].GetValue(b, null).ToStringNullSafe();
            if (aa != bb && ignore.Where(x => x == aProps[i].Name).Count() == 0)
            {
                return false;
            }
        }
        return true;
    }
