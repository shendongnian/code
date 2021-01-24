            var studentData = StudentData.GetInstance();
            //Get all students in the singleton
            var students = studentData.Students;
            
            //Add new student
            studentData.Students.Add(new Student());
            studentData.Students.Add(new Student
            {
                Intern = 1,
                Name = "SomeName"
            });
