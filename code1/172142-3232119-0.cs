    public class RowViewModel
    {
        private bool _IsModified = false;
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; _IsModified = true; }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; _IsModified = true; }
        }
    }
