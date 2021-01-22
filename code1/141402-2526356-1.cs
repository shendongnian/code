    public class Something
    {
        private string _someString = "";
        public string SomeString
        {
            get
            {
                return _someString;
            }
            set
            {
                // Some validation
                _someString = value;
            }
        }
    }
