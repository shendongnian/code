    string input = "Hello****wide****world";
    string delimiter = "****";
    
    var listOfWords = input.Split(new string[] { delimiter }, StringSplitOptions.None);
    List<string> result = new List<string>();
    
    foreach (var item in listOfWords)
    {
        if (!item.Equals(listOfWords.Last()))
        {
            result.Add(item);
            result.Add(delimiter);
        }
        else
        {
            result.Add(item);
        }
    }
