      //
      public delegate bool ContinueCopyCallback(string propertyName, Type propertyType);
      public Destination() : this(0,0) { }
      public Destination(int x, int y)
      {
         myX = x;
         myY = y;
      }
      public Destination(Source copy) : this(copy, null) { }
      public Destination(Source copy, ContinueCopyCallback callback)
      {
         foreach (PropertyInfo pi in copy.GetType().GetProperties())
         {
            PropertyInfo pi2 = this.GetType().GetProperty(pi.Name);
            if ((callback == null || (callback != null && callback(pi.Name, 
