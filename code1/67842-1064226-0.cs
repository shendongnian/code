    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
    public sealed class SingletonFactoryAttribute : Attribute
    {
    	public Type FactoryType{get;set;}	
    	public SingletonFormAttribute( Type factoryType )
    	{ 
    		FactoryType = factoryType; 
    	}
    }
