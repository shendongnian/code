    public class Courses
    {
    	//Properties (Begin property with a capital)
        public string CourseName { get; set; }
        public List<Faculty> Faculties { get; set; }
        public List<Student> Students { get; set; }
    	
        public override string ToString()
        {  
            return courseName + ", which features " + faculty.Count + ", faculty member(s) and " + student.Count + " student(s).";
        }
    }
