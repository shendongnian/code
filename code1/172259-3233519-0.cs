     public class Box
    {
    
    	public void InitializeBalls()
    	{
    		Ball ballOne = new Ball();
    		this.RegisterBall(ballOne);
    
    		Ball ballTwo = ballOne.Clone();
    		this.RegisterBall(ballTwo);
    
    	}
    
    
    	public void Ball_Bounce()
    	{
    	}
    
    	public void RegisterBall(Ball ball)
    	{
    		ball.Bounce += Ball_Bounce;
    	}
    
    }
    
    public class Ball
    {
    
    	public event BounceEventHandler Bounce;
    	public delegate void BounceEventHandler();
    
    
    	public Ball Clone()
    	{
    		Ball clonedBall = null;
    		// Do some fancy clonin'
    		return clonedBall;
    
    	}
    
    }
