    public interface ITestable {
        void RunA();
        void RunB();
    }
    public static class SystemTest
    { 
       public static void TestMethod(this ITestable item, string testString)
       {
          if(testString == "blue")
          {
             item.RunA();
          }
          else if(testString == "red")
          {
              item.RunB();
          }
          else if(testString == "orange")
          {
              item.RunA();
          }
          else if(testString == "pink")
          {
              item.RunB();
          }
       }
    }
