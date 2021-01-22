     MembershipUser user = Membership.GetUser(username);
     GenericIdentity identity = new GenericIdentity(user.UserName);
     RolePrincipal principal = new RolePrincipal(identity);
     System.Threading.Thread.CurrentPrincipal = principal;
     HttpContext.Current.User = principal;
