    class HasDateTimes
    {
      public DateTime Foo { get; set; }
      public string NotWanted { get; set; }
      public DateTime Bar { get { return DateTime.MinValue; } }
    }
    
    static void Main(string[] args)
    {
      foreach (var propertyInfo in 
        from p in typeof(HasDateTimes).GetProperties()
          where Equals(p.PropertyType, typeof(DateTime)) select p)
      {
        Console.WriteLine(propertyInfo.Name);
      }
    }
