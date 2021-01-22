    public interface ITest
    {
    	int a { get; }
    	double b { get; }
    }
    public class MyClass
    {
    	private struct test : ITest
    	{
    		private int _a;
    		private double _b;
    		
    		public int a 
    		{ 
    			get { return _a; }
    		}
    		
    		public double b 
    		{ 
    			get { return _b; }
    		}
    	}
    	public ITest PubTest
    	{
    		get { return new test() as ITest; }
    	}
    }
