    Console.Write("type a sentence: ");
    String str = Console.ReadLine();
    
    
    var result = str.Replace(" ", "")
                    .GroupBy(_ => _)
                    .Where(x => x.Count() > 1)
                    .Select(x => x.Key);
    
    foreach (var item in result)
    {
    	Console.WriteLine("duplicates: " + item);
    }
