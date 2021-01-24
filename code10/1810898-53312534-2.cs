    public class ConcreteAdaptee : IAdaptee { }
    
    public class ConcreteAdapted : IAdapted { }
    
    public class ConcreteAdapter : IGenericAdapter<ConcreteAdapted, ConcreteAdaptee>
    {
    	public ConcreteAdapted Adapt(ConcreteAdaptee adaptee)
    	{
    		// Adapt Logic
    
    		return new ConcreteAdapted();
    	}
    }
