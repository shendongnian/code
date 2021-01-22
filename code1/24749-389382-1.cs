    public class MarginCalculatorFactory
    {
    	private readonly IContainer _factoryLevelContainer;
    	public MarginCalculatorFactory(IContainer mainContainer)
    	{
            _factoryLevelContainer = mainContainer.CreateChildContainer()
            _factoryLevelContainer.RegisterType<MarginCalculator, ConcreteMarginCalculatorA>("ConcMC1");
    		_factoryLevelContainer.RegisterType<MarginCalculator, ConcreteMarginCalculatorB>("ConcMC2");
	}
	public MarginCalculator CreateCalculator(string productType)
	{
		return _factoryLevelContainer.Resolve<MarginCalculator>(productType);
	}
