    private static HashSet<string> cIPlist = new HashSet<string>();
	private static readonly Regex ipAddress = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
    private void AddToList(String IP)
    {
        var result = ipAddress.Match(IP);
        if (result.Success)                 # Check if there is a match
        {
        	if (chkQuotes.Checked)          # If the checkbox is checked
        	{
        		IP = $"\"{result.Value}\""; # Add quotes around the match value
        	}
            cIPlist.Add(IP);                # Add to hashset of strings
        }
    }
