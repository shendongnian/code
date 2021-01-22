	[TestMethod()]
	public void ReadAssemblyResourceFileTest()
	{
		var res = SetupEngine.ReadAssemblyResourceFile("newdb.sql");
		Assert.IsNotNull(res);
	}
