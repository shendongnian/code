    public class TeachersClass
        {
            private List<Student> _students;
        
            public TeachersClass(Teacher currentTeacher, List<Student> students)
            {
                CurrentTeacher = currentTeacher;
                _students = students;
            }
    
            public Teacher CurrentTeacher { get; set; }
    
            public Student this[int studentID]
            {
                get
                {
                    return (from s in _students
                            where s.Id = studentID
                            select s).First();
                }
            }   
        }
