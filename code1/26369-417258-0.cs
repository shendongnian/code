    public static bool In<T>(this T objToCheck, params T[] values)
    {
        if (values == null || values.Length == 0) 
        {
            return false; //early out
        }
        else
        {
            foreach (T t in values)
            {
                if (t.Equals(objToCheck))
                    return true;   //RETURN found!
            }
            return false; //nothing found
        }
    }
