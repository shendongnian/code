    string inputString = "1234,1235,1236,1237";
    
    string[] stringArray = inputString.Split(',');
    
    List<int> intList = stringArray.Select(x => Convert.ToInt32(x)).ToList();
    
    foreach (int i in intList)
    {
        Console.WriteLine(i);
    }
    
    Console.ReadLine();
    
