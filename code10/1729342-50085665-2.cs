    class Test
    {
        public static Action MyAction;
    }
    Test.MyAction = () => Console.WriteLine("Hello"); // Resets invocation list
    Test.MyAction(); // Invokes delegate
  
