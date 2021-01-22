    public static class RoleExtension
    {
        public static bool HasRole(this UserRole targetVal, UserRole checkVal)
        {
            return ((targetVal & checkVal) == checkVal);
        }
    }
