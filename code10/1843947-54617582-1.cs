    string GetAssociatedDirectory(string fileName,IEnumerable<string> folderNames)
    {
    	Regex regEx = new Regex(@"Cust-(?<Id>[\d]*)",RegexOptions.Compiled);
        Match match = regEx.Match(fileName);
        if (match.Success)
        {
            var customerId = match.Groups["Id"].Value;
            if(folderNames.Any(folder=>folder.EndsWith($"-{customerId}")))
    		{
    			return folderNames.First(folder=>folder.EndsWith(customerId));
    		}
    		else
    		{
    			throw new Exception("Folder not found");
    		}
        }
    	throw new Exception("Invalid File Name");
    }
