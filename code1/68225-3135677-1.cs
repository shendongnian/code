	public interface IService
	{
		void DoIt(out string a);
	}
	[TestMethod]
	public void Test()
	{
		var service = new Mock<IService>();
		var expectedValue = "value";
		service.Setup(s => s.DoIt(out expectedValue));
		string actualValue;
		service.Object.DoIt(out actualValue);
		Assert.AreEqual(actualValue, expectedValue);
	}
