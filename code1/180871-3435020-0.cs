    public class User
    {
        public int ID { get; }
    
        public string Name { get; set; }
    
        public void ChangeName(string newName)
        {
            Name = newName;
            UserEventProxy.FireUserNameChanged(this);
        }
    }
    
    public class UserEventArgs : EventArgs
    {
        public User User{get; set;}
    }
    
    /// <summary>
    /// 
    /// </summary>
    public static class UserEventProxy
    {
        /// <summary>
        /// Indicates that the associated user's name has changed.
        /// </summary>
        public static event EventHandler<UserEventArgs> UserNameChanged;
    
        /// <summary>
        /// Fires the UserNameChanged event.
        /// </summary>
        /// <param name="user">The user reporting the name change.</param>
        public static void FireUserNameChanged(User user)
        {
            EventHandler<UserEventArgs> handler = UserNameChanged;
            if (handler != null)
            {
                UserEventArgs args = new UserEventArgs()
                {
                    User = user
                };
    
                //Fire the event.
                UserNameChanged(user, args);
            }
        }
    }
    
    
    public class Mail
    {
        public Mail()
        {
            UserEventProxy.UserNameChanged += new EventHandler<UserEventArgs>(UserEventProxy_UserNameChanged);
        }
    
        private void UserEventProxy_UserNameChanged(object sender, UserEventArgs e)
        {
            User user = e.User;
    
            //
            //Presumably do something with the User instance or pass it to 
            //the SendUserInfoChangedEmail method. to do something there.
            //
    
            SendUserInfoChangeEmail();
        }
    
    
        public void SendUserInfoChangeEmail()
        {
            throw new NotImplementedException();
        }
    }
