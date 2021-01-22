    public static class GenericISomeInterfaceTests
    {
        public static void SomePropertyTest<T>(ISomeInterface<T> target, ISomeInterface<T> oracle)
        {
    
            Assert.AreEqual(oracle.SomeProperty, target.SomeProperty);
        }
    
        public static void SomeActionTest<T>(ISomeInterface<T> target, ISomeInterface<T> oracle)
        {
    
            T oracleValue = oracle.SomeAction();
            T targetValue = target.SomeAction();
    
            Assert.AreEqual(oracleValue, targetValue);
        }
    
        // More tests
    }
    
    [TestClass()]
    public class ClassAProxyTests
    {
        [TestMethod]
        public void SomePropertyStringTest()
        {
            // set up instances (using MOQ, or whatever) with the string generic type. 
            // Call them target and oracle
            
            // then call your generic test methods
            GenericISomeInterfaceTests.SomePropertyTest<string>(target, oracle);
        }
    
        [TestMethod]
        public void SomeActionStringTest()
        {
            // set up instances (using MOQ, or whatever) with the string generic type. 
            // Call them target and oracle
            
            // then call your generic test methods
            GenericISomeInterfaceTests.SomeActionTest<string>(target, oracle);
        }
    }
