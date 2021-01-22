    public class Student : Person
    {
        public int StudentID { get; protected set; }
    
        public Student(int studentID, string regNo,string name) : base(regNo,Name)
        {
            this.StudentID = studentID;
        }
    
    }
