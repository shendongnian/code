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
    
    	//Used to get full name, also usefull 
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
    		//Can use a single loop utilizing the mod operator %
    		for (int i = 1; i <= 52; i++)
    		{
    			Card.Suites suite = (Card.Suites)((i-1)%4);
    			int val = (i%14 + 1);
    			Cards.Add(new Card(val, suite));
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
