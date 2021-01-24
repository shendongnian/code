    var matches = new Dictionary<int, string>();
    matches.Add(1, "value1");
    matches.Add(2, "value5");
    matches.Add(3, "value2");
    
    var items = matches.Values.ToList();
    items.Sort( StringComparer.CurrentCulture);
    Regex rgx = new Regex(@"\D");
    var numbers = items.Select(i => int.Parse(rgx.Replace(i, "")));
     
    foreach (int c in numbers)
    {
    	Console.WriteLine(string.Format($"Number is {c}"));
    }
