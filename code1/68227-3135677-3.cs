	public interface IService
	{
		void DoSomething(out string a);
	}
	[TestMethod]
	public void Test()
	{
		var service = new Mock<IService>();
		var expectedValue = "value";
		service.Setup(s => s.DoSomething(out expectedValue));
		string actualValue;
		service.Object.DoSomething(out actualValue);
		Assert.AreEqual(actualValue, expectedValue);
	}
