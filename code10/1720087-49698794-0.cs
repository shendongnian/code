    public class CharacterStats
    {
    	public float Health {get; private set;}
    	public float HealthA2 {get; set;}
    	
    	public CharacterStats()
    	{
    		Health = 100;//I can change the value in the constructor.  Making this immutable
    	}
    	
    	public void DoWork()
    	{
    		Health = 75;//I can again change the value after construction so immutable not so much after all
    	}
    }
    
    public class PlayerStats : CharacterStats
    {
    	public void MoreWork()
    	{
    		HealthA2 = 50;//This works
    		//Health = 50;//ERROR:  I cannot change a private set in the derived class.  For that I need at least protected set;
    	}
    }
