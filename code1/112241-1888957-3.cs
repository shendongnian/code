    public class TestClassRequiringConfig : ClassRequiringConfig
    {
    	public IConfigReader ConfigReader { get; set; }
    	protected override IConfigReader GetConfigReader()
    	{
    		return this.ConfigReader;
    	}
    }
    [Test]
    public void TestMethodUsingConfig()
    {
    	ClassRequiringConfig sut = new TestClassRequiringConfig { ConfigReader = fakeConfigReader };
    	sut.MethodUsingConfig();
    	
    	//Assertions
    }
