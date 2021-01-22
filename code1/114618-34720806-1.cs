    public static bool IsOrdered<T>(this IList<T> list)
    {
        if (list.Length > 1) 
        {
            for (int i = 1; i < list.Length; i++) 
            {
                if (list[i - 1] > list[i]) 
                {
                    return false;
                }
            }
        }
        return true;
    }
