        public interface IamSam
    	{
    		int foo();
    		void bar();
    	}
    
    	public class SamExplicit : IamSam
    	{
    		#region IamSam Members
    
    		int IamSam.foo()
    		{
    			return 0;
    		}
    
    		void IamSam.bar()
    		{
    	
    		}
    
    		string foo()
    		{
    			return "";
    		}
    		#endregion
    	}
    
    	public class Sam : IamSam
    	{
    		#region IamSam Members
    
    		public int foo()
    		{
    			return 0;
    		}
    
    		public void bar()
    		{
    			
    		}
    
    		#endregion
    	}
    IamSam var1;
    var1.foo()  returns an int.
    SamExplicit var2;
    var2.foo() returns a string.
    (var2 as IamSam).foo() returns an int.
