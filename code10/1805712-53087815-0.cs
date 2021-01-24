    string input = "acdhqodcqasaf";
    var oddOccurrences = new HashSet<char>();
    var output = new StringBuilder();
    foreach (var c in input)
    {
    	if (!oddOccurrences.Contains(c))
    	{
    		output.Append(c);
    		oddOccurrences.Add(c);
    	}
    	else
    	{
    		oddOccurrences.Remove(c);
    	}
    }
    Console.WriteLine(output.ToString());
