    public class ConcreteMarginCalculatorA : MarginCalculator
    {
    	private IDependencyService1 _dependencyService1;
    	private IDependencyService2 _dependencyService2;
	
    	// Constructor dependency injection
    	public ConcreteMarginCalculatorA(
            IDependencyService1 dependencyService1,
            IDependencyService2 dependencyService2)
    	{
            this._dependencyService1 = dependencyService1;
            this._dependencyService2 = dependencyService2;
    	}
        public override double CalculateMargin
        {
            // _dependencyService1 and _dependencyService2 
            // required here to perform calcuation.
        }
    }
    public class ConcreteMarginCalculatorB : MarginCalculator
    {
    	private IDependencyService3 _dependencyService3;
    	private IDependencyService4 _dependencyService4;
	
    	// Constructor dependency injection
    	public ConcreteMarginCalculatorB(
            IDependencyService3 dependencyService3,
            IDependencyService4 dependencyService4)
    	{
    	    this._dependencyService3 = dependencyService3;
    	    this._dependencyService4 = dependencyService4;
    	}
        public override double CalculateMargin
        {
            // _dependencyService3 and _dependencyService4 
            // required here to perform calcuation.
        }
    }
