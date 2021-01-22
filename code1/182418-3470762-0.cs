    IEnumerable<T> OnlyDups<T>(this IEnumerable<T> coll) 
       where T: IComparable<T>
    {
         IEnumerator<T> iter = coll.GetEnumerator();
         if (iter.MoveNext())
         {
             T last = iter.Current;
             while(iter.MoveNext())
             {
                 if (iter.Current.CompareTo(last) == 0)
                 {
                      yield return last;
                      do 
                      {
                           yield return iter.Current;
                      }
                      while(iter.MoveNext() && iter.Current.CompareTo(last) == 0);
                      last = iter.Current;
                 }
             }
    }
