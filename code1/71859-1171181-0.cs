        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            MembershipCreateStatus status;
            MembershipUser user = _provider.CreateUser(userName, password, email, null, null, true, null, out status);
            user.LastActivityDate = DateTime.MinValue; //set the LastActivityDate to a point far back in the past
            _provider.UpdateUser(user); //update the user to the MembershipProvider
            return status;
        }
