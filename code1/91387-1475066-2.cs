     public static DateTime? GetLastLoginToMachine(string machineName, string userName)
     {
            PrincipalContext c = new PrincipalContext(ContextType.Machine, machineName);
            UserPrincipal uc = UserPrincipal.FindByIdentity(c, userName);
            return uc.LastLogon;
     }
