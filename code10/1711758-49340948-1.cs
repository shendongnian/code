    public class StudentData
    {
        private static readonly StudentData _studentData = new StudentData();
        public List<Student> Students { get; set; }
        private StudentData()
        {
            Students = new List<Student>();
        }
        public static StudentData GetInstance()
        {
            return _studentData;
        }
    }
