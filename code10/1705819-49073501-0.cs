    Console.WriteLine("enter 8 int values");
    string line = Console.ReadLine();
    List<string> myList = new List<string>(line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
    string b = "";
    Console.WriteLine("enter a number");
    while ((b = Console.ReadLine()) != "-1")
    {
        decimal prob = (decimal)myList.Where(s => s == b).Count() / myList.Count();
                
        Console.WriteLine("probability = " + prob + "\nenter a number");
                
    }
