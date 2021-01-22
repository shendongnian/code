    namespace ThanksDriis
	{
		[TestClass]
		class GlobalTestInitializer
		{
			[AssemblyInitialize()]
			public static void MyTestInitialize(TestContext testContext)
			{
				// The test framework will call this method once -BEFORE- each test run.
			}
			
			[AssemblyCleanup]
			public static void TearDown() 
			{
				// The test framework will call this method once -AFTER- each test run.
			}
		}
	}
