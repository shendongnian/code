	[TestClass]
	public class GenerarBoletinDeClase
	{
		public TestContext TestContext { get; set; }
		public static int Colegio { get; set; }
		[ClassInitialize]
		public static void ClassInitialize(TestContext testContext)
		{
			Colegio = int.Parse(testContext.Properties["colegio"].ToString()); // colegio is equal 7 in here
		}
		[TestInitialize]
		public void TestInitialize()
		{
			int tempColegio = int.Parse(this.TestContext.Properties["colegio"].ToString()); // colegio is equal 7 in here
		}
		[TestMethod]
		public void TestMethod1()
		{
			int colegio = int.Parse(this.TestContext.Properties["colegio"].ToString()); // colegio is equal 7 in here as well
			Assert.AreEqual(7, Colegio);
			Assert.AreEqual(7, colegio);
			Assert.AreEqual(colegio, Colegio);
		}
	}
