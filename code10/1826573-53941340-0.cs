    var result = lstProducts.GroupBy(x => x.Types).
                ToDictionary(g => g.Key.ToString(), g => g.Select(x => !string.IsNullOrEmpty(x.Quantity) ? Convert.ToInt32(x.Quantity) : 0).Sum().ToString());
   
    foreach (var item in result)
        Console.WriteLine(item.Key + " - " + item.Value);
    Console.ReadLine();
    
