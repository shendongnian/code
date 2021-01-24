    class Program
    {
        static void Main(string[] args)
        {
            var aPrincipal = new GenericPrincipal(new GenericIdentity("AUser", ""), new[] {"RoleA"});
            var bPrincipal = new GenericPrincipal(new GenericIdentity("BUser", ""), new[] { "RoleB" });
            var abPrincipal = new GenericPrincipal(new GenericIdentity("ABUser", ""), new[] { "RoleB", "RoleA" });
            // AB can do anything
            Thread.CurrentPrincipal = abPrincipal;
            var sc = new SecureClass();
            TryConstruct();
            TryBMethod(sc);
            TryABMethod(sc);
            // What can A do?
            Thread.CurrentPrincipal = aPrincipal;
            TryConstruct();
            TryBMethod(sc);
            TryABMethod(sc);
            // What can B do?
            Thread.CurrentPrincipal = bPrincipal;
            TryConstruct();
            TryBMethod(sc);
            TryABMethod(sc);
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
        static void TryConstruct()
        {
            try
            {
                var sc = new SecureClass();
            }
            catch(SecurityException)
            {
                Console.WriteLine("Constructor SecurityException for " + Thread.CurrentPrincipal.Identity.Name);
            }
        }
        static void TryBMethod(SecureClass sc)
        {
            try
            {
                sc.RoleBMethod();
            }
            catch (SecurityException)
            {
                Console.WriteLine("RoleBMethod SecurityException for " + Thread.CurrentPrincipal.Identity.Name);
            }
        }
        static void TryABMethod(SecureClass sc)
        {
            try
            {
                sc.RoleABMethod();
            }
            catch (SecurityException)
            {
                Console.WriteLine("RoleABMethod SecurityException for " + Thread.CurrentPrincipal.Identity.Name);
            }
        }
    }
    [PrincipalPermission(SecurityAction.Demand, Role ="RoleA")]
    class SecureClass
    {
        public SecureClass()
        {
            Console.WriteLine("In constructor using " + Thread.CurrentPrincipal.Identity.Name);
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "RoleB")]
        public void RoleBMethod()
        {
            Console.WriteLine("In RoleBMethod using " + Thread.CurrentPrincipal.Identity.Name);
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "RoleA,RoleB")]
        public void RoleABMethod()
        {
            Console.WriteLine("In RoleBMethod using " + Thread.CurrentPrincipal.Identity.Name);
        }
    }
