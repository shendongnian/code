    [C#]
    
    class XY
    {
      private X[] array;
      
      public ReadOnlyCollection<X> myObj
      {
        get
        {
          return Array.AsReadOnly(array);
        }
      }
    }
