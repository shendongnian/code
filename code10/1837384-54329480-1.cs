    var strings = new [] 
    {
        "Microsoft.MicrosoftJigsaw     All",
        "Microsoft.MicrosoftMahjong     All"
    };
            
    var keyValuePairs = new List<KeyValuePair<string, string>>();
            
    foreach(var item in strings)
    {
        var parts = item.Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);
                
        keyValuePairs.Add(new KeyValuePair<string, string>(parts[0], parts[1]));
    }
            
    var longestStringCharCount = keyValuePairs.Select(kv => kv.Key).Max(k => k.Length);
    var minSpaceCount = 5; // min space count between parts of the string
            
    var formattedStrings = keyValuePairs.Select(kv => string.Concat(kv.Key.PadRight(longestStringCharCount + minSpaceCount, ' '), kv.Value));  
            
    foreach(var item in formattedStrings)
    {
        Console.WriteLine(item);
    }
