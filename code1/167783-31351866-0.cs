    public class MyClass
    {
        public Func<DateTime> DateTimeNow = () => DateTime.Now;
        public void MyMethod()
        {
            var currentTime = DateTimeNow();
            //... do work
        }
    }
    public class MyClassTest
    {
        public void TestMyMethod()
        {
            // Arrange
            var myClass = new MyClass();
            myClass.DateTimeNow = () => new DateTime(1999, 12, 31, 23, 59, 59);
            // Act
            myClass.MyMethod();
            // Assert
            // my asserts
        }
    }
