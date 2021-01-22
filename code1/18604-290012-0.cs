        class TestClass
        {
            public int Value { get; set; }
        }
        static void Main()
        {
            Func<TestClass, int> lambdaGet = x => x.Value;
            Action<TestClass, int> lambdaSet = (x, val) => x.Value = val;
            var prop = typeof(TestClass).GetProperty("Value");
            Func<TestClass, int> reflGet = (Func<TestClass, int>) Delegate.CreateDelegate(
                typeof(Func<TestClass, int>), prop.GetGetMethod());
            Action<TestClass, int> reflSet = (Action<TestClass, int>)Delegate.CreateDelegate(
                typeof(Action<TestClass, int>), prop.GetSetMethod());
        }
