    public class TestClass
    {
    	public string Name{get;set;}
    	public TestClass()
    	{
    		Name = "Dummy Name";
    	}
    }
	var testBase = new TestBase();
	var sample = testBase.NavigateandReturntheObject<TestClass>();
	Console.WriteLine(sample.Name);
