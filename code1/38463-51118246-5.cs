    [RoutePrefix("api/v2/DIAutoExample")]
    public class DIAutoV2Controller : ApiController
    {
    	private string ConstructorInjected;
    	private string MethodInjected1;
    	private string MethodInjected2;
    	private string MethodInjected3;
    
    	[Dependency]
    	public IShape NoShape { get; set; }
    
    	[Dependency("Circle")]
    	public IShape ShapeCircle { get; set; }
    
    	[Dependency("Rectangle")]
    	public IShape ShapeRectangle { get; set; }
    
    	[Dependency("PiValueExample1")]
    	public double PiValue { get; set; }
    
    	[InjectionConstructor]
    	public DIAutoV2Controller([Dependency("Circle")]IShape shape1, [Dependency("Rectangle")]IShape shape2, IShape shape3)
    	{
    		this.ConstructorInjected = shape1.Name + " & " + shape2.Name + " & " + shape3.Name;
    	}
    
    	[NonAction]
    	[InjectionMethod]
    	public void Initialize()
    	{
    		this.MethodInjected1 = "Default Initialize done";
    	}
    
    	[NonAction]
    	[InjectionMethod]
    	public void Initialize2([Dependency("Circle")]IShape shape1)
    	{
    		this.MethodInjected2 = shape1.Name;
    	}
    
    	[NonAction]
    	[InjectionMethod]
    	public void Initialize3(IShape shape1)
    	{
    		this.MethodInjected3 = shape1.Name;
    	}
    	
    	[HttpGet]
    	[Route("constructorinjection")]
    	public string constructorinjection()
    	{
    		return "Constructor Injected: " + this.ConstructorInjected;
    	}
    
    	[HttpGet]
    	[Route("GetNoShape")]
    	public string GetNoShape()
    	{
    		return "Property Injected: " + this.NoShape.Name;
    	}
    
    	[HttpGet]
    	[Route("GetShapeCircle")]
    	public string GetShapeCircle()
    	{
    		return "Property Injected: " + this.ShapeCircle.Name;
    	}
    
    	[HttpGet]
    	[Route("GetShapeRectangle")]
    	public string GetShapeRectangle()
    	{
    		return "Property Injected: " + this.ShapeRectangle.Name;
    	}
    
    	[HttpGet]
    	[Route("GetPiValue")]
    	public string GetPiValue()
    	{
    		return "Property Injected: " + this.PiValue;
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
    
    	[HttpGet]
    	[Route("MethodInjected3")]
    	public string InjectionMethod3()
    	{
    		return "Method Injected: " + this.MethodInjected3;
    	}
    }
    
