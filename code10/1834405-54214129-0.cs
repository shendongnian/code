    readonly struct ListSegment<T> { // like ArraySegment<T>, but for List<T>
        public List<T> List {get;}
        public int Offset {get;}
        public int Count {get;}
    }
