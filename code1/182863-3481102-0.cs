    class MyClass {
        public MyClass(int x, int y) {
        }
        public int X { get; set; }
        public int Y { get; set; }
    
        public int[] ToArray() { 
            return new[] { X, Y };
        }
        public List<int> ToList() {
            return ToArray().ToList();
        }
    }
