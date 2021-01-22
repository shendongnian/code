    private static List<T> shared_list;
    
    private static ReadOnlyCollection<T> _data;
    public static IEnumerable<T> Data
    {
        get
        {
            return _data ?? (_data = shared_list.AsReadOnly());
        }
    }
