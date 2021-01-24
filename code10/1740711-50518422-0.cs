    class Management {
        List<Student> Students {get;set;}
        List<Teacher> Teachers {get; set;}
        public bool AddStudent (Student student){
            try
            {
            this.Students.Add(student);
            return true;
            }
            catch
            {
                return false;
            }
        }
    }
    abstract class Employee
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
    class Student : Employee
    {
        static List<Teacher> Teachers { get; set; }
        public static bool AddTeacher(Teacher teacher)
        {
            try
            {
                Teachers.Add(teacher);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
