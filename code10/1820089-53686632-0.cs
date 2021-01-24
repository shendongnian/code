    // Generate pattern: A|B|C
    var check_words = string.Join("|", "A", "B", "C");
    var re = new Regex($"^{check_words}");
    // Test strings
    var words = new List<string> { "Apple", "Banana", "Cucumber", "Cherry", "Watermelon" };
    var filtered =
    	words
    	.Where(word => re.IsMatch(word)) //Filter words
    	.GroupBy(g => g.Substring(0, 1)); //Group by first letter
    // Print groups
    foreach(var group in filtered)
    {
    	WriteLine($"Group: {group.Key}");
    	foreach(var x in group)
    	{
    		WriteLine($"\t{x}");
    	}
    }
    
    /*
    Output:
    Group: A
            Apple
    Group: B
            Banana
    Group: C
            Cucumber
            Cherry
    */
