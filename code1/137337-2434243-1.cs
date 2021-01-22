    struct Tuple<T1, T2> {
        public T1 Property1 { get; private set; }
        public T2 Property2 { get; private set; }
        
        public Tuple(T1 prop1, T2 prop2) {
            Property1 = prop1;
            Property2 = prop2;
        }
    }
