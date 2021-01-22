    public static int Delta(int a, int b)
    {
      int delta = 0;
      while (a < b)
      {
        ++a;
        ++delta;
      }
      while (b < a)
      {
        ++b;
        ++delta;
      }
      return delta;
    }
