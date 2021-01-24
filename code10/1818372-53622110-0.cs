    [HttpPost("search")]
	public IActionResult test(int country, decimal amount)
	{
		System.Console.WriteLine(country);
		System.Console.WriteLine(amount);
		// return an anymous object instead of a string
		return Json(new {Success = true});
	}
