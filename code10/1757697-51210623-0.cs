    //split up the source string into name value pairs
	var nameValues = sub.Split('\n')
		.Select(s => new
        {
            Name = s.Substring(0, 18).Trim(), 
            Value = s.Substring(18).Trim() 
        });
		
    //Create the token object manually
	var token = new Token
	{
		AccessToken = nameValues.Single(v => v.Name == "Access Token").Value,
		Alias = nameValues.Single(v => v.Name == "Alias").Value
	};
