    public class Test
    {
      public void TestMethod (ref string input)
      {
        input = "changed";
      }
      public void Run()
      {
        string testVar = "original";
        TestMethod(ref testVar);
        //testVar is now "changed"
      }
    }
