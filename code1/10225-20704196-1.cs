        Console.WriteLine(MyMethod(x => "Hi " + x));
        public static string MyMethod(Func<string, string> strategy)
        {
            return strategy("Lijo").ToString();
        }
