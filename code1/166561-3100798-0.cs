    void Main()
    {
    	String data = String.Empty;
    	using (StreamReader reader = new StreamReader(@"/path/to/a/file.cs"))
    		data = reader.ReadToEnd();
    	
    	CheckContents(data, "class").Dump();
    }
    
    // Define other methods and classes here
    String[] CheckContents(String data, String pattern)
    {
    	var rx = new Regex(@"{
    	(?>
    		{ (?<DEPTH> )
    		|
    		} (?<-DEPTH> )
    		|
    		[^}{]*
    	)*
    	(?(DEPTH)(?!))
    	}", RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
    	
    	var rx2 = new Regex(@"[^{]*{
    	(?>
    		{ (?<DEPTH> )
    		|
    		} (?<-DEPTH> )
    		|
    		[^}{]*
    	)*
    	(?(DEPTH)(?!))
    	}", RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
    	
    	var nameSpace = rx.Match(data).Value.Substring(1); // Remove { from namespace so we don't match the same thing over and over
    	var parts = rx2.Matches(nameSpace);
    	
    	return (from Match part in parts where Regex.IsMatch(part.Value, pattern) select part.Value.Trim()).ToArray();
    }
