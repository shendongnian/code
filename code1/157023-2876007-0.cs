    public class Test
    {
      public void TestMethod (ref int input)
      {
        input = 2;
      }
      public void Run()
      {
        int testVar = 1;
        TestMethod(ref testVar);
        //testVar is now 2
      }
    }
