    String input = "AABCD";
    var result = new Dictionary<Char, int>(26);
    var chars = input.ToCharArray();
    foreach (var c in chars)
    {
        if (!result.ContainsKey(c))
        {
            result[c] = 0; // initialize the counter in the result
        }
        result[c]++;
    }
    foreach (var charCombo in result)
    {
        Console.WriteLine("{0}: {1}",charCombo.Key, charCombo.Value);	
    }
