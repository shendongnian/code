     interface ICustomPrincipal : IPrincipal
        {
            string Id { get; set; }
    
            string FirstName { get; set; }
            string LastName { get; set; }
            string MiddleName { get; set; }
    
            string RoleName { get; set; }
        }
    
     public class CustomPrincipal : ICustomPrincipal
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string RoleName { get; set; }
    
            private string[] _roles; // Keep here English name of roles that ypu will use for Controller    [Authorize(Roles = "Administrator, Guest")]
    
            public IIdentity Identity { get; private set; }
    
            public bool IsInRole(string role)
            {
                return Array.BinarySearch(_roles, role) >= 0 ? true : false;
            }
    
            public CustomPrincipal(IIdentity identity, string[] roles)
            {
                Identity = identity;
    
                _roles = new string[roles.Length];
    
                roles.CopyTo(_roles, 0);
    
                Array.Sort(_roles);
            }
        }
    
     public class CustomPrincipalSerializeModel
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string RoleName { get; set; }
            public string RoleNameCode { get; set; } // English name of role like 'Administrator'
        }
