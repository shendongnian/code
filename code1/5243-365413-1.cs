    static void Main(string[] args)
    {
      Console.WriteLine("Name is '{0}'", GetName(new {args}));
      Console.ReadLine();
    }
    static string GetName<T>(T item) where T : class
    {
      var properties = typeof(T).GetProperties();
      Enforce.That(properties.Length == 1);
      return properties[0].Name;
    }
