    class TestBase<ChildType> where ChildType : TestBase<ChildType> {
        //public static abstract void TargetMethod();
        public static void Operation() {
            typeof(ChildType).GetMethod("TargetMethod").Invoke(null, null);
        }
    }
    class TestChild : TestBase<TestChild> {
        public static void TargetMethod() {
            Console.WriteLine("Child class");
        }
    }
