    public class Deck
    {  
    	public int DeckId { get; set; }
    	public string DeckName { get; set; }  
    	public ICollection<Card> Cards { get; set; }
    }
