    public class Program
    {
    	[DllImport( "NativeLib.dll" )]
    	private static extern bool testStuff3( [In, Out] ref IntPtr str );
    
    	static void Main( string[] args )
    	{
    		IntPtr ptr = IntPtr.Zero;
    		if( testStuff3( ref ptr ) )
    		{
    			Console.WriteLine( Marshal.PtrToStringAnsi( ptr ) );
    			Marshal.FreeCoTaskMem( ptr );
    		}
    	}
    }
