    public class WizardAttribute : Attribute
    {
    	private string[] spells;
    	public WizardAttribute(params string[] spells)
    	{
    		this.spells = spells;
    	}
    	
    	public IEnumerable<string> Spells
    	{
    		get { return this.spells ?? Enumerable.Empty<string>(); }
    	}
    }
