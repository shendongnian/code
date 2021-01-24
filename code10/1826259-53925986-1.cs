    public class Program
    {
    	public static void Main()
    	{
    		var c = new SubClass();
    		c.CallInfo();
    	}
    
    	internal class BaseClass
    	{
    		protected void Info()
    		{
    			Console.WriteLine("BaseClass");
    		}
    
    		internal virtual void CallInfo()
    		{
    			this.Info();
    		}
    	}
    
    	internal class SubClass : BaseClass
    	{
    		protected new void Info()
    		{
    			Console.WriteLine("SubClass");
    		}
    
    		internal override void CallInfo()
    		{
    			base.CallInfo();
    		}
    	}
    }
