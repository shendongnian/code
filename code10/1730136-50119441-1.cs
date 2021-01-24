    [Serializable]
    public class LootDrop
    {
    	public int Chance
    	{
    		get { return _chance; }
    		set { _chance = value; }
    	}
    
    	[SerializeField]
    	private int _chance;
    }
