	public interface IService
	{
		void DoIt(out string a);
	}
	[TestMethod]
	public void Test()
	{
		var service = new Mock<IService>();
		var a = "output value";
		service.Setup(s => s.DoIt(out a));
		string b;
		service.Object.DoIt(out b);
		Assert.AreEqual("output value", b);
	}
