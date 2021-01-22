     public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                if (!IsValidAge(value))
                    throw new ArgumentOutOfRangeException("Age","Please enter a positive age less than 100.");
    
                 _Age = value;
            }
        }
    
        private bool IsValidAge(int age)
        {
            return (age > MinAge && age < MaxAge);
        }
