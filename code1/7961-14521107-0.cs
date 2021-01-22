    public class Fruit
    {
      public string Name {get; set;}
      public int SeedCount {get; set;}
    }
    void SomeMethod()
    {
      List<Fruit> originalFruits = new List<Fruit>();
      originalFruits.Add(new Fruit {Name="Apple", SeedCount=10});
      originalFruits.Add(new Fruit {Name="Banana", SeedCount=0});
      //Deep Copy
      List<Fruit> deepCopiedFruits = from f in originalFruits
                  select new Fruit {Name=f.Name, SeedCount=f.SeedCount};
    }
