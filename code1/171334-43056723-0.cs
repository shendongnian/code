    class Sample<T> {
    
      public Sample(T lastValue, Int32 count) {
        LastValue = lastValue;
        Count = count;
      }
    
      public T LastValue { get; private set; }
    
      public Int32 Count { get; private set; }
    
    }
