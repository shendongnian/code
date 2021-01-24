    public class Student
    {
        public static int Count = 0;
        public int ID { get; set; }
        public string Name { get; set; }
        public static Dictionary<int, Student> students = new Dictionary<int, Student>();
        public Student(string name, int id)
        {
            Name = name;
            ID = id;
        }
        public static void addStudent()
        {
            Student.Count++;                                // incrementing value for new student id.
            Console.Write("Please enter student's name: "); // grabbing input from user.
            string studentName = Console.ReadLine();
            Console.WriteLine("Student ID value: {0}", Student.Count); // for testing.
            int studentID = Student.Count;
            /* Student (studentName) = new Student (studentName, studentID) -- The issue is with this line*/
            Student added = new Student(studentName, studentID);
            bool IDInUse = students.ContainsKey(added.ID);
            if(IDInUse)
            {
                students[added.ID] = added;
            }
            else
            {
                students.Add(added.ID, added);
            }
        }
    }
