    public static int Delta(int a, int b)
    {
      int delta = 0;
      if (a == b)
      {
        return 0;
      }
      else if (a < b)
      {
        while (a < b)
        {
          a++;
          delta++;
        }
        return delta;
      }
      else
      {
        while (b < a)
        {
          b++;
          delta++;
        }
        return delta;
      }
    }
