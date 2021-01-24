	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			AssertLogger.AssertWithLogs(() => Assert.IsTrue(false));
		}
		[TestMethod]
		public void TestMethod2()
		{
			AssertLogger.AssertWithLogs(() => Assert.IsTrue(false));
		}
	}
	public static class AssertLogger
	{
		public static void AssertWithLogs(Action assert)
		{
			try {
				assert();
			} catch (Exception ex) {
				//Use log4net or other loggers
				Console.WriteLine(ex.Message);
				throw ex;
			}
		}
	} 
