    public class Card
    {
    	public enum Suites
    	{
    		Hearts = 0,
    		Diamonds,
    		Clubs,
    		Spades
    	}
    
    	public int Value
    	{
    		get;
    		set;
    	}
    
    	public Suites Suite
    	{
    		get;
    		set;
    	}
    
    	//Used to get full name, also useful 
    	//if you want to just get the named value
    	public string NamedValue
    	{
    		get
    		{
    			string name = string.Empty;
    			switch (Value)
    			{
    				case (14):
    					name = "Ace";
    					break;
    				case (13):
    					name = "King";
    					break;
    				case (12):
    					name = "Queen";
    					break;
    				case (11):
    					name = "Jack";
    					break;
    				default:
    					name = Value.ToString();
    					break;
    			}
    
    			return name;
    		}
    	}
    
    	public string Name
    	{
    		get
    		{
    			return NamedValue + " of  " + Suite.ToString();
    		}
    	}
    
    	public Card(int Value, Suites Suite)
    	{
    		this.Value = Value;
    		this.Suite = Suite;
    	}
    }
    
    public class Deck
    {
    	public List<Card> Cards = new List<Card>();
    	public void FillDeck()
    	{
    		public void FillDeck()
	        {
		      //Can use a single loop utilising the mod operator % and Math.Floor
	          //Using divition based on 13 cards in a suited
		      for (int i = 0; i < 52; i++)
		      {
			     Card.Suites suite = (Card.Suites)(Math.Floor((decimal)i/13));
			     //Add 2 to value as a cards start a 2
			     int val = i%13 + 2;
			     Cards.Add(new Card(val, suite));
		      }
	         }
    	}
    	
    	public void PrintDeck()
    	{
    		foreach(Card card in this.Cards)
    		{
    			Console.WriteLine(card.Name);
    		}
    	}
    }
