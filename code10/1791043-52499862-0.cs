    public class TestClass
    {
        private class DerivedTest : SomeAbstractClass<string>
        {
            public bool WasCalled { get; private set; }
    
            protected override ResultType ValidateStronglyTypedData(string stronglyTypedData)
            {
                this.WasCalled = true;
            }
        }
    
        [YourFavoriteFrameWorkAttributeForTestMethod]
        public void TestMethod()
        {
             // arrange
             var instance = new DerivedTest();
    
             // act
             var result = instance.SomeMethod("test");
    
             // assert
             Assert.IsTrue(instance.WasCalled);    
        }
    }
