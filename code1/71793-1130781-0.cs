    public static bool IsNumber<T>(this T obj)
    {
        Type objType = obj.GetType();
        if(objType.IsPrimitive)
        {
            if (objType == typeof(object) || 
                objType == typeof(string) || 
                objType == typeof(bool))
                return false;
            return true;
        }
        return false;
    }
