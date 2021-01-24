    public class Player
    {
    	public bool Bust { get; set; }
    
        public int GetTotal()
        {
    		if (Bust)
    		{
    			return 0;
    		}
    	
    		var total = 0;
    		foreach (int card in hand)
    		{
    			total += card;
    		}
    		return total;
        }
    }
