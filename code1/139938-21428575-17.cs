    static void ShiftBits(long number,int count)
    {
        long value = 1;
        for (int i = 0; i < count; i+=128)
        {
              for (int j = 1; j < 65; j++)
              {
                  value = value << j;
              }
              for (int j = 1; j < 65; j++)
              {
                   value = value >> j;
              }
        }
    }
    
    static void MultipleAndDivide(long number, int count)
    {
          long value = 1;
          for (int i = 0; i < count; i += 128)
          {
                for (int j = 1; j < 65; j++)
                {
                    value = value * (2 * j);
                }
                for (int j = 1; j < 65; j++)
                {
                    value = value / (2 * j);
                }
          }
    }
