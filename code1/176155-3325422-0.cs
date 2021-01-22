       [TestClass]
       public class UnitTest1 {
          delegate int EventWithReturnValue();
    
          class A {
             public event EventWithReturnValue SomeEvent;
             public int LastEventResult { get; set; }
    
             public void RaiseEvent() {
                LastEventResult = SomeEvent();
             }
          }
    
          [TestMethod]
          public void TestMethod1() {
             A a = new A();
             a.SomeEvent += new EventWithReturnValue(a_SomeEvent);
             a.RaiseEvent();
             Assert.AreEqual(123, a.LastEventResult);
          }
    
          int a_SomeEvent() {
             return 123;
          }
       }
