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
				string warningMessage = Warnings.ToString();
                //-- cleared if there is more than one test running in the session
				Warnings = new StringBuilder(); 
				if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
				{
					Assert.Fail(warningMessage);
				}
				else
				{
					Assert.Inconclusive(warningMessage);
				}
			}
		}
