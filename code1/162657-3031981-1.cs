    public static class Roles 
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_CONTENT_MANAGER = "Content Manager";
    }
    // business method    
    [Security(Roles.ROLE_HR)]
    public List<Employee> GetAllEmployees();
