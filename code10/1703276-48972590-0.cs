    var result = (from s in subjects
             join ss in subjectStudents on s.SubjectID equals ss.SubjectID into SubjectStudents
                  select new
                            {
                               SubjectID = s.SubjectID,
                               Students = from ss in SubjectStudents
                                   join g in studentsGrade on ss.StudentID equals g.StudentID 
                                   select new 
                                          { 
                                               StudentId = ss.StudentID, 
                                               GradeId = g.GradeID 
                                          }
                               })
                    .ToList();
