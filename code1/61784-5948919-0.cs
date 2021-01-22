    static class IdGenerator
    {
      static int _next = 0;
      public static int GetNext()
      {
        return ++_next;
      }
    }
