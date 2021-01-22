    class Person: IPerson
    {
        private string _name;
        public string FirstName
        {
            get
            {
                return _name ?? string.Empty;
            }
            set
            {
                if (value == null)
                    throw new System.ArgumentNullException("value");
                _name = value;
            }
        }
        ...
    }
