    class MyClass {
        public CultureInfo Culture { get; set; }
        public void GetSomeString() {
            return new Int32().ToString(Culture);
        }
    }
