    interface IFrobber<out T> { T Frob(); }
    class Animal { }
    class Zebra: Animal { }
    class Tiger: Animal { }
    // Please never do this:
    class Weird : IFrobber<Zebra>, IFrobber<Tiger>
    {
      public Zebra IFrobber<Zebra>.Frob() => new Zebra();
      public Tiger IFrobber<Tiger>.Frob() => new Tiger();
    }
    …
    IFrobber<Animal> weird = new Weird();
    Console.WriteLine(weird.Frob());
