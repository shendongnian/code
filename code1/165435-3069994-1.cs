    a. By having the following
        public string MyProperty { get; private set; }
       you are making the property "read only". No one using your code can modify it's value. There are cases where this isn't strictly true (if your property is a list), but these are known and have solutions.
    b. If you decide you need to increase the safety of your code use properties:
        public string MyProperty
        {
            get { return _myField; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _myField = value;
                }
            }
        }
