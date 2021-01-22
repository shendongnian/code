    using System.DirectoryServices.AccountManagement;
    using System.Linq;
    var name = Environment.UserName;
    var user = UserPrincipal.FindByIdentity( new PrincipalContext( ContextType.Domain ), name );
    var groups = user.GetAuthorizationGroups();
    var isAdmin = groups.Any( g => g.Name == "Administrators" );    
    Console.WriteLine( "Admin: " + isAdmin );
