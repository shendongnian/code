    class Person
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal HeightCm { get; set; }
        
        public Person WithName(string firstname, string surname)
        {
            Firstname = firstname;
            Surname = surname;
            return this;
        }
        
        public Person BornOn(DateTime date)
        {
            DateOfBirth = date;
            return this;
        }
        
        public Person WithHeight(decimal heightCm)
        {
            HeightCm = heightCm;        
            return this;
        }
    }
