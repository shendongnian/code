    public interface IFlyer 
    {  
        public IFlyBehavior FlyBehavior 
    }
    
    public Bird : IFlyer
    {
    	public IFlyBehaviour FlyBehavior {get;set;}
    }
    
    public Airplane : IFlyer
    {
    	public IFlyBehaviour FlyBehavior {get;set;}
    }
