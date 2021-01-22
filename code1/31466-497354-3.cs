     static T First<T>(IEnumerable<T> items)
     {
         using(var iter = items.GetEnumerator())
         {
             iter.MoveNext();
             return iter.Current;
         }
     }
