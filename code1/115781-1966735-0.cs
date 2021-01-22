    public interface IMembershipService
    {
        int MinPasswordLength { get; }
    
        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, ...);
        bool ChangePassword(string userName, ...);
    }
