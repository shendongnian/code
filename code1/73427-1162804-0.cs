public virtual WindowsImpersonationContext Impersonate(string tokenDuplicate) {
    var tempWindowsIdentity = new System.Security.Principal.WindowsIdentity(tokenDuplicate);  
    var impersonationContext = tempWindowsIdentity.Impersonate();
    return impersonationContext;
}
