    internal class SomePlatform
    {
      public string Platform { get; set; }
      public int Count { get; set; }
    }
    internal class SomeCategory
    {
      public string Category { get; set; }
      public IEnumerable<SomePlatform> Platforms { get; set; }
    }
    internal class SomeGroup
    {
      public string AGroup { get; set; }
      public IEnumerable<SomeCategory> Categorys { get; set; }
    }
    internal class SomeClass
    {
      public string SID { get; set; }
      public IEnumerable<SomeGroup> Groups { get; set; }
    }
