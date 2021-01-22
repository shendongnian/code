    class DataProvider {
        public static IEnumerable<Something> GetData() {
            return new Something[] { ... };
        }
    }
    class Consumer {
        void DoSomething() {
            Something[] data = (Something[])DataProvider.GetData();
        }
    }
