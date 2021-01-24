    class Program
    {
      static void Main()
      {
        var obj = new Foo(Guid.NewGuid().ToString());
        Console.WriteLine(obj.Id);
        var serialize = JsonConvert.SerializeObject(obj);
        var deserialize = JsonConvert.DeserializeObject<Foo>(serialize);
        Console.WriteLine(deserialize.Id);
        Console.ReadLine();
      }
    }
    class Foo
    {
      public Foo(String Id) => this.Id = Id;        
      public string Id { get; }
    }
