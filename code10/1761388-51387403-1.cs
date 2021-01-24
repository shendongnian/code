	public override void Redirect(string location, bool permanent)
	{
		if (permanent)
		{
			HttpResponseFeature.StatusCode = 301;
		}
		else
		{
			HttpResponseFeature.StatusCode = 302;
		}
		Headers[HeaderNames.Location] = location;
	}
