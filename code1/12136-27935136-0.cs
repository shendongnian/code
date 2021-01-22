    using System.Security.Principal;
    var wi = WindowsIdentity.GetCurrent();
    var wp = new WindowsPrincipal(wi);
    var serviceSid = new SecurityIdentifier(WellKnownSidType.ServiceSid, null);
    var localSystemSid = new SecurityIdentifier(WellKnownSidType.LocalSystemSid, null);
    var interactiveSid = new SecurityIdentifier(WellKnownSidType.InteractiveSid, null);
    // maybe check LocalServiceSid, and NetworkServiceSid also
    bool isServiceRunningAsUser = wp.IsInRole(serviceSid);
    bool isSystem = wp.IsInRole(localSystemSid);
    bool isInteractive = wp.IsInRole(interactiveSid);
    bool isAnyService = isServiceRunningAsUser || isSystem || !isInteractive;
