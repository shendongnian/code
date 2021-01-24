    string nameInput = Console.ReadLine();
    List<string> animals = new List<string>(){"Bird", "Duck"};
    animals.Add("Dog");
    animals.Add("Cat");
    if (animals.Contains(nameInput))
        Console.WriteLine("Exists");
    else
        Console.WriteLine("Not Exists");
