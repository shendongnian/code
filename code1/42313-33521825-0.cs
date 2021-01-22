    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    
    public class Program
    {
        [DllImport( "advapi32.dll" ) ]
        public static extern bool InitiateSystemShutdown( string MachineName , string Message , uint Timeout , bool AppsClosed , bool Restart );
	
        [DllImport( "kernel32.dll" ) ]
        public static extern uint GetLastError();
	
        [DllImport( "kernel32.dll" ) ]
        public static extern uint FormatMessage( uint Flags , IntPtr Source , uint MessageID , uint LanguageID , StringBuilder Buffer , uint Size , IntPtr Args );
	
	
    	
    	public static void Main()
    	{
    		InitiateSystemShutdown(System.Environment.MachineName, "hello", 0, false, false);
    		//InitiateSystemShutdown("localhost", "hello", 0, false, false);
    		
    	}
    }
