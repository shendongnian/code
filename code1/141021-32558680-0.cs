    public class ServiceDiagnostics
    {
        readonly bool _isUserService;
        readonly bool _isLocalSystem;
        readonly bool _isInteractive;
        public ServiceDiagnostics()
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);
            
            var serviceSid = new SecurityIdentifier(WellKnownSidType.ServiceSid, null);
            var localSystemSid = new SecurityIdentifier(WellKnownSidType.LocalSystemSid, null);
            var interactiveSid = new SecurityIdentifier(WellKnownSidType.InteractiveSid, null);
            
            this._isUserService = wp.IsInRole(serviceSid);
            // Neither Interactive or Service was present in the current user's token, This implies 
            // that the process is running as a service, most likely running as LocalSystem.
            this._isLocalSystem = wp.IsInRole(localSystemSid);
            // This process has the Interactive SID in its token.  This means that the process is 
            // running as a console process.
            this._isInteractive = wp.IsInRole(interactiveSid);
        }
        public bool IsService
        {
            get { return this.IsUserService || this.IsLocalSystem || !this.IsInteractive; }    
        }
        public bool IsConsole
        {
            get { return !this.IsService; }
        }
        /// <summary>
        /// This process has the Service SID in its token. This means that the process is running 
        /// as a service running in a user account (not local system).
        /// </summary>
        public bool IsUserService
        {
            get { return this._isUserService; }
        }
        /// <summary>
        /// Neither Interactive or Service was present in the current user's token, This implies 
        /// that the process is running as a service, most likely running as LocalSystem.
        /// </summary>
        public bool IsLocalSystem
        {
            get { return this._isLocalSystem; }
        }
        /// <summary>
        /// This process has the Interactive SID in its token.  This means that the process is 
        /// running as a console process.
        /// </summary>
        public bool IsInteractive
        {
            get { return this._isInteractive; }
        }
    }
