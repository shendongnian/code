    public static byte[] TestCode()
    {
      MemoryStream m = new MemoryStream();
      using(m)
      {
          // ...
          // ...
          // whole bunch of stuff in between
          // ...
          // ...
    
         return m.ToArray();
      }
    }
