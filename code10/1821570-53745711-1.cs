    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
        public Exam Exam { get; set; }
        public static Student NullStudent { get; } = new Student
        {
            Name = null,
            Surname = null,
            Address = Address.NullAddress,
            Exam = Exam.NullExam,
        }
    }
