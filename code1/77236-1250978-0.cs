    static class Roles {
        public const string Administrator = "ADMIN";
    }
    static class Program {
        static void Main() {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Fred"), new string[] { Roles.Administrator });
            DeleteDatabase(); // fine
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Barney"), new string[] { });
            DeleteDatabase(); // boom
        }
    
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.Administrator)]
        public static void DeleteDatabase()
        {
            Console.WriteLine(
                Thread.CurrentPrincipal.Identity.Name + " has deleted the database...");
        }
    }
