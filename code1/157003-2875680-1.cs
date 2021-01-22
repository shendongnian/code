    public string SerializeObject<T>(object obj)
    {
      if(obj is T)
        (obj as T).someMethod();
    }
