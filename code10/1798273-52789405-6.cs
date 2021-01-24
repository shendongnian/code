    public static unsafe int Filter(this int[] array, int value, int length)
    {
       fixed (int* pArray = array)
       {
          var pI = pArray;
          var pLen = pArray + length;
          for (var p = pArray; p < pLen; p++)
             if (*p != value)
             {
                *pI = *p;
                pI++;
             }
          return (int)(pI - pArray);
       }
    }
