    [TestMethod]
    public void TestMethod1()
    {
      //if running in MSTest you have to allow for the test runner to reflect 
      //over the class as it looks for the TestClass attribute - therefore if our
      //assumption is correct that a new instance is always constructed when 
      //reflecting, our counter check should start at 2, not 1.
      Type t = typeof(AttributeTest);
      var attributes = 
        t.GetCustomAttributes(typeof(AttributeTest.TheAttributeAttribute), false);  
      //check counter
      Assert.AreEqual(2, AttributeTest.TheAttributeAttribute.Counter);
      var attributes2 = 
        t.GetCustomAttributes(typeof(AttributeTest.TheAttributeAttribute), false);
      //should be one louder (sorry, 'one bigger' - the Spinal Tap influence :) )
      Assert.AreEqual(3, AttributeTest.TheAttributeAttribute.Counter);
    }
    [TheAttribute]
    public class AttributeTest
    {
      public class TheAttributeAttribute : Attribute
      {
        static int _counter = 0;
        public static int Counter { get { return _counter; } }
        public TheAttributeAttribute()
        {
          _counter++;
          Console.WriteLine("New");
        }
      }
    }
   
