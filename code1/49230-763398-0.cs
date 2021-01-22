    class TestBase {
        protected static Action _targetMethod;
        static new() {
           _targetMethod = new Action(() => {
               Console.WriteLine("Base class");
           });
        }
        public static void TargetMethod() {
            _targetMethod();
        }
        public static void Operation() {
            TargetMethod();
        }
    }
    class TestChild : TestBase {
        static new() {
           _targetMethod = new Action(() => {
               Console.WriteLine("Child class");
           });
        }
    }
