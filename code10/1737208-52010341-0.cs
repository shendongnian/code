    internal class NativeMethods
    	{
    		// closes open handes returned by LogonUser
    		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    		public extern static bool CloseHandle(IntPtr handle);
    
    		// obtains user token
    		[DllImport("advapi32.dll", SetLastError = true)]
    		public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
    			int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    	}
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    	public sealed class Impersonation
    	{
    		/// <summary>
    		/// impersonates a user based on username/password provided. executed method after impersonation and then reverts impersonation when task/method is complete.
    		/// </summary>
    		/// <param name="userName">username to impersonate</param>
    		/// <param name="password">password for user account</param>
    		/// <param name="domain">domain of user to impersonate</param>
    		/// <param name="action">method to invoke after impersonation</param>
    		/// <param name="logonType">LogonType to use, defaulted to Network</param>
    		/// <param name="logonProvider">LogonProvider type, defaulted to default</param>
    		public static void impersonate(string userName, string password, string domain, Action action, int logonType = 2, int logonProvider = 0)
    		{
    			//elevate privileges before doing file copy to handle domain security
    			WindowsImpersonationContext context = null;
    			IntPtr userHandle = IntPtr.Zero;
    			try
    			{
    				Console.WriteLine("windows identify before impersonation: " + WindowsIdentity.GetCurrent().Name);
    				// Call LogonUser to get a token for the user
    				bool loggedOn = NativeMethods.LogonUser(userName,
    											domain,
    											password,
    											logonType,
    											logonProvider,
    											ref userHandle);
    				if (!loggedOn)
    				{
    					Console.WriteLine("Exception impersonating user, error code: " + Marshal.GetLastWin32Error());
    				}
    
    				// Begin impersonating the user
    				context = WindowsIdentity.Impersonate(userHandle);
    
    				Console.WriteLine("windows identify after impersonation: " + WindowsIdentity.GetCurrent().Name);				
    				//execute actions under impersonated user
    				action();
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine("Exception impersonating user: " + ex.Message);
    			}
    			finally
    			{
    				// Clean up
    				if (context != null)
    				{
    					context.Undo();
    				}
    
    				if (userHandle != IntPtr.Zero)
    				{
    					NativeMethods.CloseHandle(userHandle);
    				}
    			}
    		}
