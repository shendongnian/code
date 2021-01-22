	Settings.Instance.MakeNewIeInstanceVisible = false;
	using (var browser = new IE(true))
	{
		browser.GoTo(commentLink);
		browser.Link(Find.ByUrl(commentLink)).WaitUntilExists(20);
		Span commentSpan = browser.Span("COUNT_TOTAL");
		if (commentSpan.Exists)
		{
			int commentCount;
			if (Int32.TryParse(commentSpan.InnerHtml, out commentCount))
			{
				return commentCount;
			}
		}
	}
