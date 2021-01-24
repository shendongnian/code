    List<string> list1 = new List<string>
    {
        "Cat",
        "Dog",
        // etc.
    };
    List<string> list2 = new List<string>
    {
        "Gray Cat",
        "Black Cat",
        "Green Duck",
        "White Horse",
        "Yellow Dog Tasmania",
        "White Horse",
        // etc.
    };
    HashSet<string> species = new HashSet<string>(list1,
        StringComparer.CurrentCultureIgnoreCase);
    List<string> result = new List<string>();
    foreach (string animal in list2)
    {
        if (animal.Split(' ').Any(species.Contains))
            result.Add(animal);
    }
