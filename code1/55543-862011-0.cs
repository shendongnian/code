    public class UserPresenter
    {
        private User _user;
        public int Id
        {
            get { return _user.Id; }
        }
  
        public string FullName
        {
            get { return _user.LastName + " " + _user.Firstname; }
        }
    }
