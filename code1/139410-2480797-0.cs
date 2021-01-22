    public List<T> GetFoos<T>()
    {
        Type type = typeof(T);
        return Foos.Select(item => item.GetType() == type).ToList();
    }
