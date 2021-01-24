    var words = new SortedDictionary<int, string>();
    
    foreach (var com in ComJoined)
    {
        string[] splitCom = com.Split(' ');
        
        // Assuming your data is in the correct format. You could use TryParse to avoid an exception.
        words.Add(int.Parse(splitCom[0]), splitCom[1]);
    }
    
    // Do something with the sorted dictionary...
    foreach (KeyValuePair<int, string> word in words)
	    Console.WriteLine("{0} {1}", word.Key, word.Value);
