    public abstract class B1<TA, TC> where TA: A1 where TC: A1
    {
    	public TA MyA { get; protected set; }
    	public TC MyC { get; protected set; }
    }
    
    public abstract class B2<TA, TC> : B1<TA, TC> where TA : A2 where TC : A2
    {
    }
    public class B3 : B2<A3, A3>
    {
    }
