    public string Get8CharacterRandomString()
    {
    	string path = Path.GetRandomFileName();
    	path = path.Replace(".", ""); // Remove period.
    	return path.Substring(0, 8);  // Return 8 character string
    }
