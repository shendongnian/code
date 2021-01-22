    public static bool Compare(this FileInfo f1, FileInfo f2, string propertyName)
    {
        try
        {
            PropertyInfo p1 = f1.GetType().GetProperty(propertyName);
            PropertyInfo p2 = f2.GetType().GetProperty(propertyName);
            
            if (p1.GetValue(f1, null) == p2.GetValue(f1, null))
                return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        return false;
    }
