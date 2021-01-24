    namespace Example
    {
    	public class Outer
    	{
    		private Example.Inner inner = new Example.Inner(); // This is the Outer.Inner class
    
    		private class Inner { }
    	}
    
    	public class Inner { }
    }
