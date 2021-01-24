    public static int ThrowIfZero<T>(this T param)
        where T : struct
    {
        var o = (object)param;
        int i;
        try   { i = (int)o; }
        catch { throw new ArgumentException("Param must be of type int");  }
        if (i == 0) throw new ArgumentException("Must be not be zero");
        return (int)(object)param;
    }
