    var items = new[] {
      new Thing { Foo = 1, Bar = 3, Baz = "a" },
      new Thing { Foo = 1, Bar = 3, Baz = "b" },
      new Thing { Foo = 1, Bar = 4, Baz = "c" },
      new Thing { Foo = 2, Bar = 4, Baz = "d" },
      new Thing { Foo = 2, Bar = 5, Baz = "e" },
      new Thing { Foo = 2, Bar = 5, Baz = "f" }
    };
    
    var q = items
      .ToLookup(i => i.Foo) // first key
      .ToDictionary(
        i => i.Key, 
        i => i.ToLookup(
          j => j.Bar,       // second key
          j => j.Baz));     // value
    
    foreach (var foo in q) {
      Console.WriteLine("{0}: ", foo.Key);
      foreach (var bar in foo.Value) {
        Console.WriteLine("  {0}: ", bar.Key);
        foreach (var baz in bar) {
          Console.WriteLine("    {0}", baz.ToUpper());
        }
      }
    }
    
    Console.ReadLine();
