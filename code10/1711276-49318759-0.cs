    public static class ApplicationUtils
    {
        public static bool IsUserAManager(WindowsIdentity identity)
        {
            if (identity == null)
                throw new NullReferenceException("identity");
    
    
            return identity.Name == "AdminUser";
        }
    }
