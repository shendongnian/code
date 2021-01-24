    int numberOfElements = Convert.ToInt32(Console.ReadLine());
    var sb = new StringBuilder();
    
    for (int i = 0; i < numberOfElements; i++)
    {
       Console.WriteLine($"Enter value {i+1}");
       sb.AppendLine(Console.ReadLine());
    }
    
    var input = sb.ToString();
    
    // do what ever you want here
    Console.ReadKey();
