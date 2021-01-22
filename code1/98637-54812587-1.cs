    /// <summary>
    /// This class suppresses stack walks for unmanaged code permission. 
    /// (System.Security.SuppressUnmanagedCodeSecurityAttribute is applied to this class.) 
    /// This class is for methods that are safe for anyone to call. 
    /// Callers of these methods are not required to perform a full security review to make sure that the 
    /// usage is secure because the methods are harmless for any caller.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
    	[DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
    	internal static extern Int32 StrCmpLogicalW(string psz1, string psz2);
    }
