    public class TestClass
    {
	    ISomeonesDllService dllService;
	    public TestClass(ISomeonesDllService dllService)
	    {
           	this.dllService = dllService;
        }
	    public void DoSomething(string param1)
        {
       		IList<string> strings = dllService.GetList(param1);
        	// do work
    	}
    }
