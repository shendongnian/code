    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Student(int ID, string Name)
        {
            this.Name = Name;
            this.ID = ID;
        }
        public static List<Student> AllStudents = new List<Program.Student>();
        public static void AddStudent()
        {
            Console.Write("Please enter student's name: ");
            string studentName = Console.ReadLine();
            int studentID = AllStudents.Count + 1;
            Console.WriteLine("Student ID value: {0}", studentID);
            AllStudents.Add(new Student(studentID, studentName));
        }
    }
