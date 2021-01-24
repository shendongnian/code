    class Student
    {
        ...
        // instead of computing, you can set these once in the constructor
        public DateTime BirthDay => GetBirthDay(this.PersonalCode);
        public TimeSpan Age => GetAge(this.BirthDay);
        ...
        private TimeSpan GetAge(DateTime birthDate) { ... }
    }
