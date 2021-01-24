    string sibling1, sibling2;
    int age_sibling1, age_sibling2;
    Console.WriteLine(" Insert your name and your age ");
    sibling1 = Console.ReadLine();
    age_sibling1 = int.Parse(sibling1);
    Console.WriteLine(" Insert your sibling's name and age ");
    sibling2 = Console.ReadLine();
    age_sibling2 = int.Parse(sibling2);
    
    if (age_sibling1 > age_sibling2) 
        Console.WriteLine($"{sibling1} is bigger ");
    else
        Console.WriteLine($"{sibling2} is bigger ");
