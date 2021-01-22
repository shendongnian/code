    List<SuperHero> heroes = new List<SuperHero>();
    heroes.Add(new SuperHero(1, "Superman", 0));
    heroes.Add(new SuperHero(2, "Batman", 3));
    heroes.Add(new SuperHero(3, "Watchman", 1));
    heroes.Add(new SuperHero(4, "Wolverine", 2));
    foreach (SuperHero hero in heroes)
        Console.WriteLine(hero.ToString());
    Console.WriteLine();
    heroes.Sort();
    foreach (SuperHero hero in heroes)
        Console.WriteLine(hero.ToString());
