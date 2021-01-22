    // Membership service that just provides Create/Delete
    public interface IMembershipService
    {
        IMembershipUser CreateUser(string username, string password);
        void DeleteUser(string username);
    }
