     static T First<T>(IEnumerable<T> items)
     {
         using(IEnumerator<T> iter = items.GetEnumerator())
         {
             iter.MoveNext();
             return iter.Current;
         }
     }
