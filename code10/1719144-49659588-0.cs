    class MyDate : DateTime
    {
      public int(int year, int month, int day)
      {
          try
         {
            base(-1, -1, -1)
         }
         catch
        {
        }
      }
    }
