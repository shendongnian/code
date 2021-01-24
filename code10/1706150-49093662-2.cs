	string lives = "";
	if (pageContent.Contains(item.Anchor))
	{
		lives = "Indexed";
	}
	else
	{
		// ...
		if (pageContent.Contains(item.Anchor))
		{
			lives = "Live";
		}
		// We can have lives == "" at this point, which Enum.Parse won't process
		
		// ...
	}
