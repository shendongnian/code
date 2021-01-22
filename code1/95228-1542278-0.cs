    public class TestClass
    {
        private static TestClass instance = LoadObject();
        private TestClass(){ }
        private static TestClass LoadObject()
        {
            var t = new TestClass();
            //do init
            return t;
        }
        public static  TestClass GetObject()
        {
            return instance;
        }
    }
