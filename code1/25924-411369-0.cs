    public static CompareList<T>(IList<T> obj1, IList<T> obj2, Action<T,T> match)
    {
       if (obj1.Count != obj2.Count) return false;
       for (int i = 0; i < obj1.Count; i++)
       {
         if (obj2[i] != null && !match(obj1[i], obj2[i]))
           return false;
       }
    }
