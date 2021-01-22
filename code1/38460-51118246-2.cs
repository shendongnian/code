    [RoutePrefix("api/v2/DIExample")]
    public class DIV2Controller : ApiController
    {
    	private string ConstructorInjected;
    	private string MethodInjected1;
    	private string MethodInjected2;
    	public string MyPropertyName { get; set; }
    	public double PiValue1 { get; set; }
    	public double PiValue2 { get; set; }
    	public IShape Shape { get; set; }
    
    	// MethodInjected
    	[NonAction]
    	public void Initialize()
    	{
    		this.MethodInjected1 = "Default Initialize done";
    	}
    
    	// MethodInjected
    	[NonAction]
    	public void Initialize2(string myproperty1, IShape shape1, string myproperty2, IShape shape2)
    	{
    		this.MethodInjected2 = myproperty1 + " & " + shape1.Name + " & " + myproperty2 + " & " + shape2.Name;
    	}
    
    	public DIV2Controller(string myproperty1, IShape shape1, string myproperty2, IShape shape2)
    	{
    		this.ConstructorInjected = myproperty1 + " & " + shape1.Name + " & " + myproperty2 + " & " + shape2.Name;
    	}
    
    	[HttpGet]
    	[Route("constructorinjection")]
    	public string constructorinjection()
    	{
    		return "Constructor Injected: " + this.ConstructorInjected;
    	}
    
    	[HttpGet]
    	[Route("PropertyInjected")]
    	public string InjectionProperty()
    	{
    		return "Property Injected: " + this.MyPropertyName;
    	}
    
    	[HttpGet]
    	[Route("GetPiValue1")]
    	public string GetPiValue1()
    	{
    		return "Property Injected: " + this.PiValue1;
    	}
    
    	[HttpGet]
    	[Route("GetPiValue2")]
    	public string GetPiValue2()
    	{
    		return "Property Injected: " + this.PiValue2;
    	}
    
    	[HttpGet]
    	[Route("GetShape")]
    	public string GetShape()
    	{
    		return "Property Injected: " + this.Shape.Name;
    	}
    
    	[HttpGet]
    	[Route("MethodInjected1")]
    	public string InjectionMethod1()
    	{
    		return "Method Injected: " + this.MethodInjected1;
    	}
    
    	[HttpGet]
    	[Route("MethodInjected2")]
    	public string InjectionMethod2()
    	{
    		return "Method Injected: " + this.MethodInjected2;
    	}
    }
    
