    protected void OnLoggingIn(object sender, LoginCancelEventArgs e)
        {
            // Accesses the database to get the logged-in user.
            MembershipUser userInfo = Membership.GetUser(LoginUser.UserName);
            UserMan.UserID = userInfo.ProviderUserKey.ToString();
            if (Application[UserMan.UserID] != null)
            {
                if (Convert.ToString(Application[UserMan.UserID]) == UserMan.UserID)
                {
                    e.Cancel = true;
                }
                else
                {
                    // Save the user id retrieved from membership database to application state.
                    Application[UserMan.UserID] = UserMan.UserID;
                }
            }
            else
            {
                Application[UserMan.UserID] = UserMan.UserID;                
            }
        }
