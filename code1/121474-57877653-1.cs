    class Client
    {
      static void Main()
      {
        PersonDB p = new PersonDB();
        p.Process(PrintName);
      }
      static void PrintName(string name)
      {
        System.Console.WriteLine(name);
      }
    }
