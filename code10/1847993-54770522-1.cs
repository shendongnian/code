    public class SomeClass : Base
    {
    	public static void SomeMethod1()
    	{
    		//Do something
    	}
    
    	public static void SomeMethod2()
    	{
    		//Do something
    	}
    
    	public static void WrapperMethod(Action action)
    	{
    		Base.ThisWillBeCalledBEFOREAnyMethodInChild();
    		action();
    		Base.ThisWillBeCalledAFTERAnyMethodInChild();
    	}
    
    }
