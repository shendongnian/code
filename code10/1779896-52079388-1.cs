    private static bool compareObj(object obj1, object obj2)
    {
        bool flag = true;
        try
        {
            object result = Convert.ChangeType(obj1, obj2.GetType());
            object result2 = Convert.ChangeType(obj2, obj1.GetType());
            var first = Marshal.SizeOf(obj1.GetType());
            var second = Marshal.SizeOf(obj2.GetType());
            if (first > second)
            {
                 flag = obj1.Equals(result2);
            }
            else
            {
                 flag = obj2.Equals(result);
            }
        }
        catch (InvalidCastException ex)
        {
            flag = false;
        }
    
        return flag;
    }
