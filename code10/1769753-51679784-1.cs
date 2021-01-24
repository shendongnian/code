	[DataTestMethod]
	[MyDataRow("sampleString", true)]
	[MyDataRow("sampleString2")]
	public async Task SampleTest(string parameterA, bool parameterB = false)
	{
		var condition = await AsyncOperation();
		Assert.AreEqual(parameterB, condition);
	}
