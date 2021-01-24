    class Student
    {
        public string Name { get; set; }
        public Student(string name)
        {
            this.Name = name;
        }
    }
    var s = new System.Collections.Generic.List<Student>();
    s.Add(new Student("John"));
    s.Add(new Student("Dick"));
    s.Add(new Student("Harry"));
