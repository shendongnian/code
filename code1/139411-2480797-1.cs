    public List<T> GetFoos<T>()
    {
        Type type = typeof(T);
        return Foos.Where(item => item.GetType() == type).ToList();
    }
