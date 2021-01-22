    public class MyClassUsingExtensions
    {
        public string ReturnStringForObject(object obj)
        {
            return obj.MyMethod();
        }
    }
 
    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void MyTest()
        {
            // Given:
            //-------
            var mockMyImplementation = new Mock<IMyImplementation>();
 
            MyExtensions.Implementation = mockMyImplementation.Object;
 
            var myObject = new Object();
            var myClassUsingExtensions = new MyClassUsingExtensions();
 
            // When:
            //-------
            myClassUsingExtensions.ReturnStringForObject(myObject);
 
            //Then:
            //-------
            // This would fail because you cannot test for the extension method
            //mockMyImplementation.Verify(m => m.MyMethod());
 
            // This is success because you test for the mocked implementation interface
            mockMyImplementation.Verify(m => m.MyMethod(myObject));
        }
    }
