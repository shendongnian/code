    public class Final : IFinal
    {
    	public delegate Final Factory(int runtimeArgument);
    	
    	public Final(IDependency dependency, int runtimeArgument) { }
    
    	public void Test() { }
    }
