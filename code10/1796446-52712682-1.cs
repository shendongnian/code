    public class TestClass {
        private int _age;
        public string _name;
        public TestClass(int age, string name) {
            _name = name;
            _age = age;
        }
        public static void Test() {
            var fieldReader = new FieldReader<TestClass>();
            var obj1 = new TestClass(12, "Angie");
            var obj2 = new TestClass(42, "Bob");
            Debug.WriteLine("Angie:");
            fieldReader.ShowFieldValuesforObject(obj1);
            Debug.WriteLine("Bob:");
            fieldReader.ShowFieldValuesforObject(obj2);
        }
    }
