    public class MembershipWrapper : IMembershipFactory
    {
        #region IMembership Members
        public IMembershipUser CreateUser(string email, string password)
        {
            var user = System.Web.Security.Membership.CreateUser(email, password, email);
            return new MembershipUserWrapper(user);
        }
        public void DeleteUser(string userName)
        {
            System.Web.Security.Membership.DeleteUser(userName);
        }
        #endregion
    }
