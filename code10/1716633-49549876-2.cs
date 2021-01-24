    class Program {
        static void Main(string[] args) {
            var test = new Test();
            test.TestEvent += OnTest;            
            var backingField = typeof(Test).GetField("TestEvent", BindingFlags.Instance | BindingFlags.NonPublic);
            var delegateInstance = (Action)backingField.GetValue(test);
            delegateInstance();            
        }
        private static void OnTest() {
            Console.WriteLine("Event invoked");
        }
    }
    class Test {
        public event Action TestEvent;
    }
