    var _currentRunspace = RunspaceFactory.CreateRunspace(this);
    /* XXX: We need to enable dot-sourcing - unfortunately there is no 
     * way in code to just enable it in our host, it always goes out to
     * the system-wide settings. So instead, we're installing our own
     * dummy Auth manager. And since PSh makes us reimplement a ton of
     * code to make a custom RunspaceConfiguration that can't even properly 
     * be done because we only have the public interface, I'm using 
     * Reflection to hack in the AuthManager into a private field. 
     * This will most likely come back to haunt me. */
    var t = typeof(RunspaceConfiguration);
    var f = t.GetField("_authorizationManager", BindingFlags.Instance | BindingFlags.NonPublic);
    f.SetValue(_currentRunspace.RunspaceConfiguration, new DummyAuthorizationManager());
    _currentRunspace.Open();
    return _currentRunspace;
    public class DummyAuthorizationManager : AuthorizationManager
    {
        const string constshellId = "Microsoft.PowerShell";
        public DummyAuthorizationManager() : this (constshellId) {}
        public DummyAuthorizationManager(string shellId) : base(shellId) {}
        protected override bool ShouldRun(CommandInfo commandInfo, CommandOrigin origin, PSHost host, out Exception reason)
        {
            // Looks good to me!
            reason = null;
            return true;
        }
    }
    
