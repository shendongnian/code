    public class Student
    {
        public bool IsStudent { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
    public static void Main(string[] args)
    {
        Student GetDefault(params Action<Student>[] modifiers)
        {
            var stu = new Student
            {
                IsStudent = true
            };
            if (modifiers != null)
            {
                foreach (var modifier in modifiers)
                {
                    modifier(stu);
                }
            }
            return stu;
        }
        var student = GetDefault(
            s => s.Age = 18,
            s => s.Name = "Nick"
        );
    }
