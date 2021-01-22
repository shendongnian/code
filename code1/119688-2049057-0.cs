    public static bool ContainsType<T>()
    {
        object[] objects = new object[] { };
    
        foreach (var o in objects)
        {
            if (o is T)
            {
                return true;
            }
        }
    
        return false;
    }
    
    public static void Main(string[] args)
    {
        ContainsType<int>();
    }
