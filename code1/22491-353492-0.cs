    public int Compare(T x, T y)
    {
         PropertyInfo[] props = x.GetType().GetProperties();
    
         foreach(PropertyInfo info in props)
         {
              if(info.name == y.GetType().Name)
              ....
         }
         ...
