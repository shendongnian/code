    using System.Runtime.InteropServices;
    using System;
    using System.Security;
    using System.Security.Permissions;
    using System.Collections;
    using System.IO;
    using System.Text;
    
    namespace MyOfficeNetAddin
    {
        /// <devdoc>
        ///     This class is intended to use with the C# 'using' statement in
        ///     to activate an activation context for turning on visual theming at
        ///     the beginning of a scope, and have it automatically deactivated
        ///     when the scope is exited.
        /// </devdoc>
    
    [SuppressUnmanagedCodeSecurity]
    internal class EnableThemingInScope : IDisposable
    {
       // Private data
       private IntPtr cookie; // changed cookie from uint to IntPtr
       private static ACTCTX enableThemingActivationContext;
       private static IntPtr hActCtx;
       private static bool contextCreationSucceeded = false;
    
       public EnableThemingInScope(bool enable)
       {
         if (enable)
         {
           if (EnsureActivateContextCreated())
           {
             if (!ActivateActCtx(hActCtx, out cookie))
             {
               // Be sure cookie always zero if activation failed
               cookie = IntPtr.Zero;
             }
           }
         }
      }
    
      // Finalizer removed, that could cause Exceptions
      // ~EnableThemingInScope()
      // {
      //    Dispose(false);
      // }
    
      void IDisposable.Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
    
      private void Dispose(bool disposing)
      {
         if (cookie != IntPtr.Zero)
         {
            if (DeactivateActCtx(0, cookie))
            {
               // deactivation succeeded...
               cookie = IntPtr.Zero;
            }
         }
      }
    
      private bool EnsureActivateContextCreated()
      {
       lock (typeof(EnableThemingInScope))
       {
        if (!contextCreationSucceeded)
        {
         // Pull manifest from the .NET Framework install
         // directory
    
         string assemblyLoc = null;
                            
         FileIOPermission fiop = new FileIOPermission(PermissionState.None);
         fiop.AllFiles = FileIOPermissionAccess.PathDiscovery;
         fiop.Assert();
         try
         {
            assemblyLoc = typeof(Object).Assembly.Location;
         }
         finally
         { 
            CodeAccessPermission.RevertAssert();
         }
    
         string manifestLoc = null;
         string installDir = null;
         if (assemblyLoc != null)
         {
            installDir = Path.GetDirectoryName(assemblyLoc);
            const string manifestName = "XPThemes.manifest";
            manifestLoc = Path.Combine(installDir, manifestName);
         }
    
         if (manifestLoc != null && installDir != null)
         {
             enableThemingActivationContext = new ACTCTX();
             enableThemingActivationContext.cbSize = Marshal.SizeOf(typeof(ACTCTX));
    	     enableThemingActivationContext.lpSource = manifestLoc;
    
             // Set the lpAssemblyDirectory to the install
             // directory to prevent Win32 Side by Side from
             // looking for comctl32 in the application
             // directory, which could cause a bogus dll to be
             // placed there and open a security hole.
    	     enableThemingActivationContext.lpAssemblyDirectory = installDir;
    	     enableThemingActivationContext.dwFlags = ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID; 
     
    	     // Note this will fail gracefully if file specified
             // by manifestLoc doesn't exist.
             hActCtx = CreateActCtx(ref enableThemingActivationContext);
             contextCreationSucceeded = (hActCtx != new IntPtr(-1));
         }
        }
    
        // If we return false, we'll try again on the next call into
        // EnsureActivateContextCreated(), which is fine.
        return contextCreationSucceeded;
       }
      }
    
      // All the pinvoke goo...
      [DllImport("Kernel32.dll")]
      private extern static IntPtr CreateActCtx(ref ACTCTX actctx);
      // changed from uint to IntPtr according to 
      // https://www.pinvoke.net/default.aspx/kernel32.ActiveActCtx
      [DllImport("Kernel32.dll", SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool ActivateActCtx(IntPtr hActCtx, out IntPtr lpCookie);
      // changed from uint to IntPtr according to 
      // https://www.pinvoke.net/default.aspx/kernel32.DeactivateActCtx
      [DllImport("Kernel32.dll", SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool DeactivateActCtx(int dwFlags, IntPtr lpCookie);
    
      private const int ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID = 0x004;
                
      private struct ACTCTX 
      {
         public int       cbSize;
         public uint      dwFlags;
         public string    lpSource;
         public ushort    wProcessorArchitecture;
         public ushort    wLangId;
         public string    lpAssemblyDirectory;
         public string    lpResourceName;
         public string    lpApplicationName;
      }
     }
    }
