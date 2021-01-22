    class Name
    {
        private string MFullName="";
        private int MYearOfBirth;
        public string FullName
        {
            get
            {
                return(MFullName);
            }
            set
            {
                if (value==null)
                {
                    throw(new InvalidOperationException("Error !"));
                }
            
                MFullName=value;
            }
        }
        public int YearOfBirth
        {
            get
            {
                return(MYearOfBirth);
            }
            set
            {
                if (MYearOfBirth<1900 || MYearOfBirth>DateTime.Now.Year)
                {
                    throw(new InvalidOperationException("Error !"));
                }
                MYearOfBirth=value;
            }
        }
        public int Age
        {
            get
            {
                return(DateTime.Now.Year-MYearOfBirth);
            }
        }
        public string FullNameInUppercase
        {
            get
            {
                return(MFullName.ToUpper());
            }
        }
    }
