    class MyList<T> {
        void AddRange<U>(IEnumerable<U> items) where U: T {
            foreach (U item in items) {
                Add(item);
            }
        }
    }
