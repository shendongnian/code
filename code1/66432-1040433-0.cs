    List<string> list = new List<string>();
    list.Add("This is a sentence.");
    list.Add("This is another one.");
    list.Add("C# is fun.");
    list.Add("Linq is also fun.");
    
    System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex("This");
    
    var qry = list
        .Where<string>(item => regEx.IsMatch(item))
        .ToList<string>();
    
    // Print results
    foreach (var item in qry)
    {
        Console.WriteLine(item);
    }
