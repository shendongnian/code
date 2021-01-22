    [TestClass]
    public class ATest {
      Mock<IMyService> myService ;
      [TestInitialize]
      public void InitialiseClass() {
        myService = new Mock<IMyService>();
      }
      [TestMethod]
      public void DoWorkShouldCallDoIt {
        A a = new A();
        a.MyService = myService.Object;
        a.DoWork();
        myService.Verify(m=>m.DoIt(), Times.Once());
      }
    }
