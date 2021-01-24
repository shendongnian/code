    static void Main(string[] args)
        {
            QA students = new QA();
            foreach (var s in students.students)
            {
                Console.WriteLine(s.GetStudents());
            }
        }
