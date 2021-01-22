       public class UnitTest1 {
          class MyStringable {
             public static implicit operator MyStringable(string value) {
                return new MyStringable();
             }
          }
    
          [TestMethod]
          public void MyTestMethod() {
             MyStringable foo = "abc";
          }
       }
