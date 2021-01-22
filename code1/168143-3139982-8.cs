    class Player
    {
    	private int health;
    	public int Health
    	{
    		get
    		{
    			if (health <= 0)
    			{
    				Die();
    			}
    			
    			return health;
    			
    		}
    		
    		set
    		{
    			health = value;
    		}
    	}
    	
    	public void Die()
    	{
    		// OMG I DIED, Call bunch of other methods:
    		// RemoveFromMap();
    		// DropEquipment(); etc
    	}
    }
