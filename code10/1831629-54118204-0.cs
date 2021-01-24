    static void ParseLog()
    {
    	var s = File.ReadAllText(@"C:\log.json");
    	var pattern =
    		@"(?s)(?'header'\[\w+\]\d{1,2}/\d{1,2}/\d{4}\s\d{1,2}:\d{1,2}:\d{1,2}\s(A|P)M\r\n" +
    		@"<?==>?.+?\r\n)" +
    		@"(?'body'.+?)(?=$|\[\w+\]\d{1,2}/\d{1,2}/\d{4}\s\d{1,2}:\d{1,2}:\d{1,2}\s(A|P)M)";
    	var matches = Regex.Matches(s, pattern);
    	if (matches.Count > 0)
    	{
    		JToken last_json = null;
    		try
    		{
    			var text = matches[matches.Count - 1].Groups["body"].Value;
    			last_json = JToken.Parse(text);
    			WriteLine(last_json.ToString());
    		}
    		catch (Exception ex) { WriteLine(ex.ToString()); }
    	}
    	else
    	{
    		WriteLine("No matches found");
    	}
    }
