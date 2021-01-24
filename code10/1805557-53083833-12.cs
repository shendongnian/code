    public class StudentInfo
    {
        public int sl { get; set; }
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string school { get; set; }
        public string program { get; set; }
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public string cellPhone { get; set; }
        public string gender { get; set; }
        public string dateOfBirth { get; set; }
    }
    
    public class RootClass
    {
        public List<StudentInfo> data { get; set; }
        public string message { get; set; }
        public int total { get; set; }
    }
