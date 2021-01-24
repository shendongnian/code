    public class Head
    {
    	public static int eyeCount;
    	public int eyelashCount;
    	
    	public GrowEyeLash()
    	{
    		eyelashCount++; //accessing a normal variable
    	}
    	
    	public SetEyeCount(int eyes)
    	{
    		Head.eyeCount = eyes; //accessing a static variable
    	}
    }
