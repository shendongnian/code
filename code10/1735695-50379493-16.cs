    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    
    [assembly: ComVisible(true)] 
    [assembly: AssemblyDelaySign(false)] 
    [assembly:AssemblyKeyFileAttribute("Managed.snk")]
    [assembly: AssemblyVersion("1.0.0.0")]
    namespace ManagedClassLibrary {
    	
    	[Guid("1CE4ECCB-EB78-4A50-8781-444052C7AEAE")]
    	[ComVisible(true)]
    	public interface IArithmetic {
    		int sum(int lsh, int rhs);
    		int subtract(int lsh, int rhs);
    	}
    	[Guid("30F078F9-F161-4112-B61A-B3BD6B63CB4C"), 
    		ClassInterface(ClassInterfaceType.None), 
    		ComSourceInterfaces(typeof(IArithmetic))
    	]
    	[ComVisible(true)]
    	public class ArithmeticImpl:IArithmetic {
    		
    		public int sum(int lsh, int rhs)
    		{
    			 return lsh + rhs;
    		} 
    		public int subtract(int lsh, int rhs)
    		{
    			 return lsh - rhs;
    		}
    	}
    
    }
