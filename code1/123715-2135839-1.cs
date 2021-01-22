    class IndexerTest {
        public int this[int index] {
            get {
                return 0;
            }
        }
        public string this[int index] {
            get {
                return "Hello, fail!";
            }
        }
    }
