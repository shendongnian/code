    public void Destroy(T obj)
    {
        if (obj == null)
            throw new ArgumentNullException("obj");
        if (!_living.Contains(obj))
            throw new ArgumentException("Where did this obj come from?");
    
        using (obj as IDisposable)
        {
    
        }
        
        _living.Remove(obj); // List?
    }
