    public class Customer
    {
        private Field _firstName = new Field(typeof(string), 20);
    
        public string FirstName
        {
            get
            {
                return _firstName.Value as string;
            }
            set
            {
                _firstName.Value = value;
            }
        }
    }
