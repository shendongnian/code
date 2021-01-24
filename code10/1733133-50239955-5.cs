    class Student
    {
        public static List<Student> CreateStudents(params string[] names)
        {
            List<Student> students = new List<Student>();
            foreach (string stName in names)
            {
                students.Add(new Student(stName));
            }
            return students;
        }
        // Rest of your class.
        // .
    }
