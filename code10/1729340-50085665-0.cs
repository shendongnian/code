    class Test
    {
        public static Action MyAction;
    }
    Test.MyAction = () => Console.WriteLine("Hello"); // Reset invocation list
    Test.MyAction(); // Call delegate
  
