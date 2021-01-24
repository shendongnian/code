    class ClassWithRefField {
        public TestClass Field;
    }
    class ClassWithStructField {
        public TestStruct Field;
    }
    class TestClass {
        public TestClass(int payload) {
            Payload = payload;
        }
        public int Payload;
    }
    struct TestStruct {
        public TestStruct(int payload)
        {
            Payload = payload;
        }
        public int Payload;
    }
