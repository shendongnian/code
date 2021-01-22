    class IndexerTest {
        public int this[int index] {
            get {
                return 0;
            }
        }
        public string this[double index] {
            get {
                return "Hello, success!";
            }
        }
    }
