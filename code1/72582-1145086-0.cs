    internal static class TrustHelper
    {
        static TrustHelper()
        {
            try
            {
                var permission = new AspNetHostingPermission(
                    AspNetHostingPermissionLevel.High);
                permission.Demand();
                TrustHelper.IsHighlyTrusted = true;
            }
            catch (SecurityException)
            {
                TrustHelper.IsHighlyTrusted = false;
            }
        }
        public static bool IsHighlyTrusted()
        {
            get;
            private set;
        }
    }
