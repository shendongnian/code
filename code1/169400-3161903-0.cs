       [TestClass]
       public class WhenFoo
       {
          [TestMethod]
          public void TestFoo()
          {
             string str = ConfigurationManager.AppSettings["WhenFooTestFooString"];
          }
       }
