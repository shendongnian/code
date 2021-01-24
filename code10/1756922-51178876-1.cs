    static void Main(string[] args)
        {
            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "Colin",
                    LastName = "Firth"
                }
            };
            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Mary",
                    LastName = "Sue"
                },
                new Student
                {
                    FirstName = "Joseph",
                    LastName = "Jojo"
                }
            };
            var softEngCourse = new Course("Software Engineering", teachers, students);
            var bachelorDegree = new Degree("Bachelor", softEngCourse);
            var technologyProgram = new UProgram("Technology", bachelorDegree);
            Console.ReadLine();
        }
