    Dictionary<string, string> myCollection = new Dictionary<string, string>();
    
    myCollection.Add("(.*)orange(.*)", "Oranges are a fruit.");
    myCollection.Add("(.*)apple(.*)", "Apples have pips.");
    myCollection.Add("(.*)dog(.*)", "Dogs are mammals.");
    // ...
    
    string input = "tell me about apples and oranges";
    
    var results = from result in myCollection
                  where Regex.Match(input, result.Key, RegexOptions.Singleline).Success
                  select result;
    
    foreach (var result in results)
    {
        Console.WriteLine(result.Value);
    }
    
    // OUTPUT:
    //
    // Oranges are a fruit.
    // Apples have pips.
