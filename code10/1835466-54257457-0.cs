    class C : IFoo { 
      public Mammal X(Mammal y)
      {
        Console.WriteLine(y.HairColor);
        return new Giraffe();
      }
    }
