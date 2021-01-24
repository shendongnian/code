    //can be a class as well if You need it to be
    public interface Item 
    {
	    List<Usage> PossibleUsages {get;}		
    }
    public enum Usage
    { Eat, Drink, Wear, ThrowAway }
    public class Food : Item
    {
	    public List<Usage> PossibleUsages
	    {
		    get => new List<Usage> { Usage.Eat }
	    }
	    public void Do(Usage whatToDo)
	    {
		    switch(whatToDo)
		    {
			    case Usage.Eat: Eat(); break;
			    default: throw new ArgumentException("Unsupported action", nameof(whatToDo));
		    }		
	    }
	    private void Eat()
	    {
		    //Your stuff
	    }
    }
 
