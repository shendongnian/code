    public class Pair<T, U> {
        public Pair() {
        }
    
        public Pair(T first, U second) {
            this.first = first;
            this.second = second;
        }
    
        public T First { get; set; }
        public U Second { get; set; }
    };
