    [TestClass]
    public class MyTest
    {
        [ThreadStatic]
        public static int Run = 1;
        
        [TestInitialize]
        public void TestInit()
        {
            if (Run == 1) 
            {
                //...
            }
            else if (Run == 2) 
            { 
                //...
            }
        }
        
        [MyTestMethod]
        public void MyTestMethod() 
        {
            //...
        }
    }
    public class MyTestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            MyTest.Run = 1;
            var result1 = testMethod.Invoke(null);
            MyTest.Run = 2;
            var result2 = testMethod.Invoke(null);
            return new TestResult[] { result1, result2 };
        }
    }
