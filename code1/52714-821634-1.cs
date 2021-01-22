    public static class SomeUtilityClass {
        public static string GetUsername() {
            IPrincipal principal = Thread.CurrentPrincipal;
            IIdentity identity = principal == null ? null : principal.Identity;
            return identity == null ? null : identity.Name;
        }
    }
    ...
    
    record.UpdatedBy = record.CreatedBy = SomeUtilityClass.GetUsername();
