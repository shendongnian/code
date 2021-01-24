    void Main()
    {
    	FooStruct fooStruct = new FooStruct() { FooProp = 1234 };
    	FooStruct fooStructDefault = default(FooStruct);
    	FooClass fooClass = new FooClass();
    	FooClass fooClassDefault = default(FooClass);
    	IsDefaultIFoo(fooStructDefault).Dump();
    	IsDefaultIFoo(fooStruct).Dump();
    	IsDefaultIFoo(fooClassDefault).Dump();
    	IsDefaultIFoo(fooClass).Dump();
    	
    }
    public bool IsDefaultIFoo(IFoo foo)
    {
    	if(foo != null && foo.GetType().IsValueType)
    	{
    		return foo.Equals(Activator.CreateInstance(foo.GetType()));
    	}
    	else
    	{
    		return foo == default(IFoo);	
    	}	
    }
    
    public interface IFoo { }
    public struct FooStruct : IFoo
    { 
    	public int FooProp { get; set;}
    }
    public class FooClass : IFoo { }
