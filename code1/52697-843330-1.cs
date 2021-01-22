     [Serializable, AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = false), ComVisible(true)] 
     public sealed class AdministratorPrincipalPermissionAttribute : CodeAccessSecurityAttribute 
     { 	
        public AdministratorPrincipalPermissionAttribute(SecurityAction action) : base(action)
        { }
          
        public override IPermission CreatePermission()
        {
           var identifier = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
           var role = identifier.Translate(typeof(NTAccount)).Value;
           return new PrincipalPermission(null, role);
        }
     }
