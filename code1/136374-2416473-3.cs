    // Your static class - hard to mock
    class StaticClass
    {
       public static int ReturnOne() 
       {
           return 1;
       }
    }
    // Interface that you'll use for a wrapper
    interface IStatic
    {
        int ReturnOne();
    }
