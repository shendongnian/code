    class Department
    {
        public int Id {get; set;}
        ...
        // Every department has zero or more Students (one-to-many)
        public virtual ICollection<Student> Students {get; set;}
    }
    class Student
    {
        public int Id {get; set;}
        ...
        // every Student belongs to exactly one department, using foreign key
        public int DepartmentId {get; set;}
        public virtual Department Department {get; set;}
    }
