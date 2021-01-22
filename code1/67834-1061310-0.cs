class OuterClass {
    private class BadClassBase {
        // whatever BadClass does 
    }
    private class BadClass<T> : BadClassBase {
        public BadClass(T item) {
            ...
        }
    }
}
