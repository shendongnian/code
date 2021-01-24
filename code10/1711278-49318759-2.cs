    public static class ApplicationUtils
    {
        public static bool IsUserAManager(IIdentity identity)
        {
            if (identity == null)
                throw new NullReferenceException("identity");
    
    
            return identity.Name == "AdminUser";
        }
    }
