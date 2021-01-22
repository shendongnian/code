    namespace Blah.Controls
    {
    	public class CommonControl { }
    
    	public static class Common
    	{
    		public static void Foo(this CommonControl cc) { }
    	}
    
    	public class Control1 : CommonControl
    	{
    		public void Bar()
    		{
    			this.Foo();
    		}
    	}
    }
 
