    var yummy = new List<string>();
    while(person.FeelsHappy()) {
        yummy.Add(person.GetNewFavoriteFood());
    }
    Console.WriteLine("Sweet! I have a list of size {0}.", list.Count);
    Console.WriteLine("I didn't even need to know how big to make it " +
        "until I finished making it!");
