    // IMembershipUser that provides a lot of the necessary details
    public interface IMembershipUser
    {
        string UserName { get; }
        bool IsApproved { get; }
        bool IsLockedOut { get; }
        string Email { get; }
        DateTime LastLoginDate { get; }
        DateTime CreationDate { get; }
        bool ChangePassword(string oldPassword, string newPassword);
        string ResetPassword();
        Guid UserID { get; }
    }
