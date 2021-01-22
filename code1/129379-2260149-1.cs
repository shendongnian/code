    namespace Blop.Controls
    {
    	public static class Common
    	{
    		public static void Foo() { }
    	}
    
    	public partial class Control1
    	{
    		public void Bar()
    		{
    			Foo();
    		}
    	}
    
    	public partial class Control1
    	{
    		public void Foo()
    		{
    			Common.Foo();
    		}
    	}
    } 
