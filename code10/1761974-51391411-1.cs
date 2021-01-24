    Console.Write("Enter the First String: ");
    var firstString = Console.ReadLine();
    Console.Write("Enter the 2nd   String: ");
    var secondString = Console.ReadLine();
    var list1 = firstString.ToList();
    var list2 = secondString.ToList();
    list1.Sort();
    list2.Sort();
    if (list1.SequenceEqual(list2))
        Console.Write("Matched");
    else
        Console.Write("Not Matched");
