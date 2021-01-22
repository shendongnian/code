    using Earlz.BareMetal;
    
    ...
    Console.WriteLine(BareMetal.SizeOf<int>()); //returns 4 everywhere I've tested
    Console.WriteLine(BareMetal.SizeOf<string>()); //returns 8 on 64-bit platforms and 4 on 32-bit
    Console.WriteLine(BareMetal.SizeOf<Foo>()); //returns 16 in some places, 24 in others. Varies by platform and framework version
    
    ...
    
    struct Foo
    {
      int a, b;
      byte c;
      object foo;
    }
