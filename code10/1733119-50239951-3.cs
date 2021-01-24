    class Student
    {
        public string Name { get; set; }
        public Student(string name)
        {
            this.Name = name;
        }
    }
    class StudentList : List<Student>
    {
    }
