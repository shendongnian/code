    public static T ConvertFromDBVal<T>(object obj)
    {
        if (obj == null || obj == DBNull.Value) {
            return default(T);
        }
        else
        {
            return (T)obj;
        }
    }
