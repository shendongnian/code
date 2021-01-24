    public extension class List2DExt<T> : List<List<T>> 
    {
        // Extension static field
        private static int _flattenCount = 0;
        // Extension static property
        public static int FlattenCount => _flattenCount;
        // Extension static method
        public static int Get FlattenCount() => _flattenCount;
        // New syntax for extension methods
        public List<T> Flatten() { ... }
        // Extension indexers
        public List<List<T>> this[int[] indices] => ...;
        // Extension implicit operator
        public static implicit operator List<T>(List<List<T>> self) => self.Flatten();
        // Extension operator overload
        public static implicit List<List<T>> operator +(List<List<T>> left, List<List<T>> right) => left.Concat(right);
    }
