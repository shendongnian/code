	public IActionResult Index()
	{
		if (User.IsInRole("CustomisedTheme"))
		{
			return CustomisedIndex();
		}
		else
		{
			return DefaultIndex();
		}
	}
	private IActionResult CustomisedIndex()
	{
		// Complex logic to populate view
		// ...
		return View("CustomisedIndex");
	}
	private IActionResult CustomisedIndex()
	{
		// Complex logic to populate view
		// ...
		return View("CustomisedIndex");
	}
