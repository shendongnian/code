      class TestClass: System.Collections.IEnumerable {
        public void Add(int value) { }
    
        public IEnumerator GetEnumerator() {
          return null;
        }
      }
    
      ...
    
      TestClass myTest = new TestClass() {1, 2, 3};  
