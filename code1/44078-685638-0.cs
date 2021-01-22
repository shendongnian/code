    class Foo<T> {
        void Test(T value) {
            Bar bar = new Bar();
            bar.Value = value;
        }
        class Bar {
            public T Value { get; set; }
        }
    }
