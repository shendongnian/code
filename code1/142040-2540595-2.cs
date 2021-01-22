    using System;
    using System.Security.Principal;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {
                IIdentity identity =
                    new IdentityStub
                        {
                            Name = "Robert",
                            AuthenticationType = "Kerberos",
                            IsAuthenticated = true
                        };
    
                IPrincipal principal = new PrincipalStub(identity);
    
                Console.WriteLine(principal.Identity.Name);  // Robert
                Console.WriteLine(principal.IsInRole(PrincipalStub.ValidRole));  // True
                Console.WriteLine(principal.IsInRole("OtherRole"));  // False
            }
        }
    
        public class PrincipalStub : IPrincipal
        {
            public const string ValidRole = "TestRole";
    
            public PrincipalStub(IIdentity identity)
            {
                Identity = identity;
            }
    
            public IIdentity Identity { get; private set; }
    
            public bool IsInRole(string role)
            {
                return role == ValidRole;
            }
        }
    
        public class IdentityStub : IIdentity
        {
            public string Name { get; set; }
            public string AuthenticationType { get; set; }
            public bool IsAuthenticated { get; set; }
        }
    }
