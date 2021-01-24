      class TestClass: System.Collections.IEnumerable {
        public void Add(int value) { }
    
        public IEnumerator GetEnumerator() {
          // Just to demonstrate, do not do this in production code
          return null;
        }
      }
    
      ...
    
      TestClass myTest = new TestClass() {1, 2, 3};  
