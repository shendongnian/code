    static void Main(string[] args)
    {
      var dto = Mapper.FromTuple(() => ReturnsATuple()).Map<Dto>();
      Console.WriteLine($"Foo: {dto.Foo}, Bar: {dto.Bar}");
      Console.Read();
    }
    public static (string Foo, int Bar) ReturnsATuple()
    {
      return ("A", 1);
    }
    class Dto
    {
      public string Foo { get; set; }
      public int Bar { get; set; }
    }
