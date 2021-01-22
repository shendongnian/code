    class Person
    {
        private string _name; 
        public string Name 
        { 
            get 
            {
                return string.IsNullOrEmpty(_name) ? "Default Name" : _name;
            } 
            set { _name = value; } 
        }
    }
