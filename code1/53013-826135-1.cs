    public static bool Any(object a, params object[] b)
    {
        foreach(object item in b)
        {
            if(a == b)
            {
                return true;
            }
        }
        return false;
    }
