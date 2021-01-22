    public static bool IsNumber<T>(this T obj)
    {
        if (Equals(obj, null))
        {
            return false;
        }
        Type objType = typeof(T);
        if (objType.IsPrimitive)
        {
            return objType != typeof(bool) && 
                objType != typeof(char) && 
                objType != typeof(IntPtr) && 
                objType != typeof(UIntPtr);
        }
        return objType == typeof(decimal);
    }
