        var student= context.Students.FirstOrDefault(a => a.Name == "vic");
        var grade= context.Grades.FirstOrDefault(b => b.Grade == 2);
        var studentGrade = context.StudentsGrades.Include(a => a.Students).Include(b => b.Grades)
                   .FirstOrDefault(c => c.Students.Name == "vic" && c.Grades.Grade = 2);
        if (studentGrade == null)
        {
            context.StudentsGrades.Add(new StudentGrade 
            {                    
                StudentId = student.Id,
                GradeId = grade.Id
            });
        }
        context.SaveChanges();
