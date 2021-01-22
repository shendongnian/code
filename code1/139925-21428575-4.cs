    static void ShiftBits(long number,int count)
    {
       for (int i = 0; i < count; i++)
       {
          var shiftedValue = number << i;
       }
    }
     static void Multiple(long number, int count)
     {
        for (int i = 0; i < count; i++)
        {
            var shiftedValue = (long)Math.Pow(number, i);
        }
    }
