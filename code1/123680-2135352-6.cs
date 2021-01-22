    public class ThreadSafeClass
    {
    	public double A { get; private set; }
    	public double B { get; private set; }
    	public double C { get; private set; }
    
    	public ThreadSafeClass(double a, double b, double c)
    	{
    	    A = a;
    	    B = b;
    	    C = c;
    	}
    
    	public ThreadSafeClass RecalculateA()
    	{
    	    return new ThreadSafeClass(2.0 * B, B, C);
    	}
    }
