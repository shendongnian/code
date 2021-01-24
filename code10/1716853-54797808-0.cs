    /// <summary>
	/// Post api/dostuff/{id}
	[HttpPost]
	[Route("dostuff/{id}")]
	public async Task<IActionResult> DoStuff([FromBody]Model model, int id)
	{
		// Both model and id are available for use!
	}
