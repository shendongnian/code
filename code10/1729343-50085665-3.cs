    class Test
    {
        public static event Action MyAction;
    }
    Test.MyAction = () => Console.WriteLine("Hello"); // Not allowed
    Test.MyAction(); // Not allowed
    Test.MyAction += () => Console.WriteLine("Hello"); // Only this is allowed
