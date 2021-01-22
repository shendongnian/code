    class IntCollection : Collection<int> {
        public IntCollection() : base() { }
        public IntCollection(IList<int> data) : base(data) { }
        public static implicit operator int[](IntCollection items) {
            return items.ToArray(); // LINQ, but can do manually
        }
        public static implicit operator IntCollection (int[] items){
             return new IntCollection(items);
        }
    }
