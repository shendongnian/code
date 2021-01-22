    public void Method<T>()
    {
      Type type = typeof(T);
    
      T newObject = (T)type.GetConstructor(new System.Type[] { }).Invoke(new object[] { });
    }
