      class TestClass: IEnumerable<int> {
        private List<int> Numbers = new List<int>();
    
        // This is required
        public void Add(int value) {
          Numbers.Add(value);
        }
    
        public IEnumerator<int> GetEnumerator() {
          return Numbers.GetEnumerator();
        }
    
        // This is required
        IEnumerator IEnumerable.GetEnumerator() {
          return GetEnumerator();
        }
      }
