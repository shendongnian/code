    public class Final : IFinal
    {
    	public delegate IFinal Factory(int runtimeArgument);
    	
    	public Final(IDependency dependency, int runtimeArgument) { }
    
    	public void Test() { }
    }
