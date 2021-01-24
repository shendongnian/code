    static class Program
    {
        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public Student(int ID, string Name)
            {
                this.Name = Name;
                this.ID = ID;
            }
        }
    
        public class Students : List<Student>
        {
            public void Add()
            {
                Console.Write("Please enter student's name: ");
                string studentName = Console.ReadLine();
                int studentID = base.Count + 1;
                Console.WriteLine("Student ID value: {0}", studentID);
                base.Add(new Student(studentID, studentName));
            }
        }
    
        static void Main()
        {
            Students students = new Students();
            students.Add();
        }
    }
