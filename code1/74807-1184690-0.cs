    public static void AlternateSplitting(SSL src, SSL odd, SSL even)        
    {
    #if DEBUG
      int srcCount = CountList(src);
    #endif
      while (src.Head != null) { blah blah blah }
    #if DEBUG
      int oddCount = CountList(odd);
      int evenCount = CountList(even);
      Debug.Assert(CountList(src) == 0);
      Debug.Assert(oddCount + evenCount == srcCount);
      Debug.Assert(oddCount == evenCount || oddCount == evenCount + 1);
    #endif
    }
