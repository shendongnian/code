    private static List<T> shared_list;
    
    public static IEnumerable Data
    {
        get
        {
            return shared_list.AsReadOnly();
        }
    }
