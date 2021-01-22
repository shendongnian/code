    using System.Runtime.InteropServices;
    
    namespace Test {
    	public class Test {
    		public static Main() {
    			Hello("C#");
    		}
    		
    		[DllImport("test.dll", EntryPoint="hello", CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
    		public static extern Hello(string from_);
    	}
    }
