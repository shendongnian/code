    [Test]
	public void StringsMatch_OnlyString1NullOrEmpty_ReturnFalse()
	{
		Authentication auth = new Authentication();
		Assert.IsFalse(auth.StringsMatch(null, "foo"));
		Assert.IsFalse(auth.StringsMatch("", "foo"));
	}
