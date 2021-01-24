    static void Create([TupleElementNames(new string[] {"username", "password"})] ValueTuple<string, string> usernameAndPassword)
    {
      Console.WriteLine(usernameAndPassword.Item1);
      Console.WriteLine(usernameAndPassword.Item2);
    }
