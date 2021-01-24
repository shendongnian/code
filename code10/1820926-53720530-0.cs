    class School
    {
        public int Id {get; set;}          // will become the primary key
        public string Name {get; set;}
        ... // other properties
        // every School has zero or more Students (one-to-many)
        public virtual ICollection<Student> Students {get; set;}
    }
    class Student
    {
        public int Id {get; set;}          // will become the primary key
        public string Name {get; set;}
        public DateTime BirthDate {get; set;}
        ... // other properties
        // every Student belongs to exactly one School, using foreign key:
        public int SchoolId {get; set;}
        public virtual School School {get; set;}
    }
