            List<Student> students = new List<Student>();
            Student student = new Student() { Name = "StudentName", Surname = "StudentSurname", Address = new Address() { City = "City", Country = "Country" }, Exam = new Exam() { ExamMark = "ExamMark", ExamName = "ExamName", Teacher = new Teacher() { TeacherName = "TeacherName", TeacherSurname = "TeacherSurname" } } };
            Student student2 = new Student() { Name = "StudentName", Surname = "StudentSurname", Address = new Address(), Exam = new Exam() { ExamMark = "ExamMark", ExamName = "ExamName", Teacher = new Teacher() } };
            students.Add(student);
            students.Add(student2);
            List<Student> results = new List<Student>();
            foreach (var item in students)
            {
                var result = ConvertToNull(item);
                results.Add(result);
            }
