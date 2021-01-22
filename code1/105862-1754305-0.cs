    Console.WriteLine("bla bla - enter xx to exit");
    string line;
    while(line = Console.ReadLine() != "xx")
    {
      string result = DoSomethingWithThis(line);
      Console.WriteLine(result);
    }
