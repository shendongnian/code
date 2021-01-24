    public static class ApplicationUtils {
        public static Func<IIdentity> userFactory = () => WindowsIdentity.GetCurrent();
        public static IIdentity CurrentUser { get { return userFactory(); } }
        public static bool IsManager(this IIdentity identity) {
            return identity != null && string.Compare(identity.Name, "AdminUser", true) == 0;
        }
        public static bool IsAuthenticated(this IIdentity identity) {
            return identity != null && identity.IsAuthenticated;
        }
    }
	
