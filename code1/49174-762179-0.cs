    private static Dictionary<Type,int> nameSuffixCounters =
         new Dictionary<Type,int>();
    public string CreateName()
    {
        Type type = this.GetType();
        return string.Format("{0}{1}",type.Name, this.GetNextAndIncrement(type));
    }
    private int GetNextAndIncrement(Type type)
    {
        int current;
        if (!this.nameSuffixCounters.TryGetValue(type, out current))
        {
            current = 0;
        }
        nameSuffixCounters[type] = ++current;
        return current;
    }
