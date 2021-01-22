    public interface ILogonHelpers
    {
         bool LogonUser( string user, string domain, string password, ref int token );
         void DuplicateToken(  int token, ref int duplicateToken );
    }
    public class MyClass
    {
        public MyClass( ILogonHelper logonHelper, IIdentityFactory factory )
        {
            this.LogonHelper = logonHelper ?? new DefaultLogonHelper();
            this.IdentityFactory = factory ?? new DefaultIdentityFactory();
        }
 
        ...
    if (this.LogonHelper.Logon(user, domain, password, ref token) > 0)
    {
        if (this.LogonHelper.DuplicateToken(token, ref tokenDuplicate))
        {
            var tempWindowsIdentity = this.IdentityFactory.CreateIdentity(tokenDuplicate);
            var impersonationContext = tempWindowsIdentity.Impersonate();
            ...
        }
    ...
    }
        
