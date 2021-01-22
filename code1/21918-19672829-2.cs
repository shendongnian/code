    public void Each<T>(Action<T> action)
    {
        foreach (var item in items)
        {
            action(item);
        }
     }
