    public abstract class Message
    {
    	internal abstract bool Check();
    }
    
    public class MyMessage : Message
    {
    	internal override bool Check()
    	{
    		// do stuff
    	}
    }
