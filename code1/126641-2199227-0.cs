    public Object2 GetObject2()
     {
      lock (LockObject)
      {
        using (var ob = new Object2)
        {
            return ob.Get();
        }
      }
     }
