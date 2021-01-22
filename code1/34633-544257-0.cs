    public static class SmartEnumerable {
      public static SmartEnumerable<T> Create<T>(IEnumerable<T> source) {
        return new SmartEnumerable<T>(source);
      }
    }
    
    void Example() {
      var se = SmartEnumerable.Create(myCats);
    }
