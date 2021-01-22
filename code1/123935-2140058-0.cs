    T t = obj as T;
     //some other thread changes obj to another type...
    if (t != null) action(t); //still works
    if (obj is T)
    {
         //bang, some other thread changes obj to another type...
         action((T)obj); //InvalidCastException
    }
