	[TestClass]
	public static class AssemblyInitializer
	{
		[AssemblyInitialize]
		public static void Initialize(TestContext context)
		{
			Startup.IsRunningInUnitTest = true;
		}
	}
