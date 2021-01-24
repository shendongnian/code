    public interface IMethodsExecutor
    {
    	void Execute();
    	void ShouldRunMethod1();
    	void ShouldRunMethod2();
    	void ShouldRunMethod3();
    }
    
    public class MethodsExecutor: IMethodsExecutor
    {
    	private bool _runMethod1;
    	private bool _runMethod2;
    	private bool _runMethod3;
    
    	public MethodsExecutor()
    	{
    		_runMethod1 = false;
    		_runMethod2 = false;
    		_runMethod3 = false;
    	}
    
    	public void ShouldRunMethod1()
    	{
    		_runMethod1 = true;
    	}
    	public void ShouldRunMethod2()
    	{
    		_runMethod2 = true;
    	}
    	public void ShouldRunMethod3()
    	{
    		_runMethod3 = true;
    	}
    
    	private void Method1()
    	{
    	}
    	private void Method2()
    	{
    	}
    	private void Method3()
    	{
    	}
    	public void Execute()
    	{
    		if (_runMethod1)
    		{
    			Method1();
    		}
    		if (_runMethod2)
    		{
    			Method2();
    		}
    		if (_runMethod3)
    		{
    			Method3();
    		}
    	}
    }
