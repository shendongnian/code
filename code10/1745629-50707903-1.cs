    [PrincipalPermission(SecurityAction.Demand, Role = "RoleA")]
    class Foo
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "RoleA")]
        public Foo()
        {
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "RoleA")]
        [PrincipalPermission(SecurityAction.Demand, Role = "RoleB")]
        public static bool Bar()
        {
            return true;
        }
    }
