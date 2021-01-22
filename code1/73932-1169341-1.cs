    public class DynamicTwoDimensonalArray<T>
    {
      private List<List<T>> Items = new List<List<T>>();
    
      public T this[int i1, int i2]
      {
        get
        {
          return Items[i1][i2];
        }
        set
        {
          Items[i1][i2] = value;
        }
      }  
    }
