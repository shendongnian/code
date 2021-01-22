        public class MembershipUserWrapper : IMembershipUser
    {
        private MembershipUser _User;
        public MembershipUserWrapper(MembershipUser user)
        {
            _User = user;
        }
        #region IMembershipUser Members
        public string ResetPassword()
        {
            return _User.ResetPassword();
        }
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            return _User.ChangePassword(oldPassword, newPassword);
        }
        public string UserName
        {
            get { return _User.UserName; }
        }
        public bool IsApproved
        {
            get { return _User.IsApproved; }
        }
        public bool IsLockedOut
        {
            get { return _User.IsLockedOut; }
        }
        public string Email
        {
            get { return _User.Email; }
        }
        public DateTime LastLoginDate
        {
            get { return _User.LastLoginDate; }
        }
        public DateTime CreationDate
        {
            get { return _User.CreationDate; }
        }
        public Guid UserID
        {
            get { return (Guid)_User.ProviderUserKey; }
        }
        #endregion
    }
