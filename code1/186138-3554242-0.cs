    public sealed class Person
    {
        public string Name = string.Empty;
        public string Firstname = string.Empty;
        public string Middlename = string.Empty;
    
        public string Fullname
        {
            get { return string.Concat(Name, Firstname, Middlename); }
        }
    
    }
