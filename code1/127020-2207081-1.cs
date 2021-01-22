    class Foo {
        private int count = 0;
        public List<Int32> foos = new List<Int32>();
        public List<Int32> bars = new List<Int32>();
        public int DoCounting() {
           int count = bars.Count;
           for (int i = 0; i < count; ++i) {
               bars[i]++;
           }
           foreach (Int32 foo in foos) {
               if (foo > 50) ++count;
           }
           return count;
        }
    }
