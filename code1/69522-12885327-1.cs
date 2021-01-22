    using System.Runtime.InteropServices;
    
    internal static class Useful {
    	[DllImport("shell32.dll", EntryPoint = "IsUserAnAdmin")]
    	public static extern bool IsUserAnAdministrator();
    }
