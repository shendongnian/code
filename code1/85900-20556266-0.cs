    public class BaseTestClass
    {
    	public static StringBuilder Warnings;
    
    	[SetUp]
    	public virtual void Test_SetUp()
    	{
    	    	Warnings = new StringBuilder();
    	}
		[TearDown]
		public virtual void Test_TearDown()
		{
			if (Warnings.Length > 0)
			{
				if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
				{
					Assert.Fail(Warnings.ToString());
				}
				else
				{
					Assert.Inconclusive(Warnings.ToString());
				}
			}
		}
