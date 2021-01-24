    public static unsafe bool UnsafeCompare(int[] ary1, int[] ary2)
    {
       fixed (int* pAry1 = ary1, pAry2 = ary2)
       {
          var pLen = pAry1 + ary1.Length;
          for (int* p1 = pAry1, p2 = pAry2; p1 < pLen; p1++, p2++)
             if (*p1 != *p2)
                return false;
       }
       return true;
    }
    
