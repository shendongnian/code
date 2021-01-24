	Link.Live lives = Link.Live.Dead;
	if (pageContent.Contains(item.Anchor))
	{
		lives = Link.Live.Indexed;
	}
	else
	{
		// ...
		if (pageContent.Contains(item.Anchor))
		{
			lives = Link.Live.Live;
		}
		// No need to parse from a string...
		
		// ...
	}
