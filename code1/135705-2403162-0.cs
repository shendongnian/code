    public interface Hand
    {
       IEnumerable<int> PossibleValues { get; set; }
    }
    public interface Card
    {
       CardValues PossibleValues { get; set; }
    }
    public interface CardValues
    {
    	int Value1 { get; }
    	int Value2 { get; }
    }
    
    public class BlackjackHand : Hand
    {
    	IList<Card> cards;
    
       public IEnumerable<int> PossibleValues
       {
    		IList<int> possible_values = new List<int>();
    
    		int initial_hand_value = cards.Sum(c => c.Value1);
    		if(initial_hand_value <= 21)
    		{
    			possible_values.Add(initial_hand_value);
    			yield return initial_hand_value;
    		}
    
    		foreach(Card card in cards.Where(c => c.Value2 > 0))
    		{
    			IList<int> new_possible_values = new List<int>();
    			foreach(int value in possible_values)
    			{
    				var alternate_value = value + card.Value2;
    				if(alternate_value <= 21) 
    				{
    					new_possible_values.Add(alternate_value);
    					yield return alternate_value;
    				}
    			}
    			possible_values.AddRange(new_possible_values);
    		}
    
    		yield break;
       }
    }
