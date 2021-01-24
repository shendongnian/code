    string name;
    float age;
    List<universe> collection = new List<universe>();
    
    for (int i = 0; i < 10; i++)
    {
    	universe main = new universe();
    	
        Console.WriteLine("name");
        name = Console.ReadLine();
        Console.WriteLine("age");
        age = float.Parse(Console.ReadLine());
        main.Galaxy(name, age);
        collection.Add(main);
    }
    
    foreach (universe b in collection) 
    {
        Console.WriteLine($"{b.Name} {b.Age}"); // <== I don't know if universe class has Name and Age properties
    }
