    class MostRecentList<T> : System.Collections.Generic.List<T> {
            private int capacity;
    
            public MostRecentList(int capacity) : base() {
                this.capacity = capacity;
            }
    
            public new void Add(T item) {
                if (base.Count == capacity) {
                    base.RemoveAt(0);
                }
                base.Add(item);
            }
    }
