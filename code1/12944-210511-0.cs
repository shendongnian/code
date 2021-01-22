    public delegate void BeforeRemoveMatchCallback<T>(T item1, T item2);
    public static void RemoveMatches<T>(
                    IList<T> list1, IList<T> list2, 
                    BeforeRemoveMatchCallback<T> beforeRemoveCallback) 
      where T : IComparable<T>
    {
      // looping backwards lets us safely modify the collection "in flight" 
      // without requiring a temporary collection (as required by a foreach
      // solution)
      for(int i = list1.Count - 1; i >= 0; i--)
      {
        for(int j = list2.Count - 1; j >= 0; j--)
        {
          if(list1[i].CompareTo(list2[j]) == 0)
          {
             // do any cleanup stuff in this function, like your role assignments
             if(beforeRemoveCallback != null)
               beforeRemoveCallback(list[i], list[j]);
             list1.RemoveAt(i);
             list2.RemoveAt(j);
             break;
          }
        }
      }
    } 
