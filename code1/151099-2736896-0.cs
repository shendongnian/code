    public class Outer
    {
    	private class Nested : IFace
    	{
    		public Nested(...)
    		{
    		}
            //interface member implementations...
    	}
    	
    	public IFace GetNested()
    	{
    		return new Nested();
    	}
    }
