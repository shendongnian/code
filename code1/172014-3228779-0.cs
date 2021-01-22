    public class User
    {
        public IList<Friend> Friends
        {
            get { return _friends; }
            set { _friends = new List<Friend>(value); }
        }
    
        private List<Friend> _friends;
    }
