    public static T Parse<T>(string s)
    {
        Type t = typeof(T);
        // Attempt to execute the Parse method on the type if it exists. 
        MethodInfo parse = t.GetMethod("Parse", new Type[] { typeof(string) });
        if (parse != null)
        {
            try
            {
                return (T)parse.Invoke(null, new object[] { s });
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        else
        {
            throw new MethodAccessException(String.Format("The Parse method does not exist for type {0}.", t.Name));
        }
    }
    public static bool TryParse<T>(string s, out T result)
    {
        return TryParse<T>(s, false, out result);
    }
    public static bool TryParse<T>(string s, bool throwException, out T result)
    {
        result = default(T);
        Type t = typeof(T);
        T type = default(T);
        // Look for the TryParse method on the type. 
        MethodInfo tryParse = t.GetMethod("TryParse", new Type[] { typeof(string), Type.GetType(t.FullName + "&") });
        if (tryParse != null)
        {
            // Try parse exists. Call it. 
            Object[] ps = new Object[2];
            ps[0] = s;
            bool isSuccess = (bool)tryParse.Invoke(type, ps);
            if (isSuccess)
                result = (T)ps[1];
            return isSuccess;
        }
        else
        {
            // TryParse does not exist. Look for a Parse method. 
            try
            {
                result = Parse<T>(s);
                return true;
            }
            catch (Exception ex)
            {
                if (throwException)
                    throw ex;
                return false;
            }
        }
    }
