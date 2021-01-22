    public class Parent
    {
    	public virtual object Obj{get;set;}
    	public Parent()
    	{
    		// Re-sharper warning: this is open to change from 
    		// inheriting class overriding virtual member
    		this.Obj = new Object();
    	}
    }
