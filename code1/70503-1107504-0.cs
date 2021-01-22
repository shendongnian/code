    class Collection
    {
       public String this[int i]
       {
          get
          {
             if (i <= a1.Length)
                return a1[i];
             else
                return a1[a1.Length + i];
          }
          set { }
       }
       String[] a1 = new String[] { "one", "two" };
       String[] a2 = new String[] { "three", "four" };
    }
