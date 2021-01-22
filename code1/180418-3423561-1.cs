    public class SalesForm : Form
    {
        private string _userName = null;
        public string UserName 
        { 
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                if(!String.IsNullOrEmpty(_userName))
                    Text = "Currently Logged In: " + _userName;
            }
        }
    }
