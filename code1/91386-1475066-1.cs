      public static DateTime? GetLastLogin(string domainName,string userName)
      {
            PrincipalContext c = new PrincipalContext(ContextType.Domain,domainName);
            UserPrincipal uc = UserPrincipal.FindByIdentity(c, userName);
            return uc.LastLogon;
       }
