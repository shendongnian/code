     public IEnumerable<Grade> GetGradesOfStudentFromSubject(Guid subjectId)
     {
         var subject= _context.Subject.FirstOrDefault(g => g.SubjectId == subjectId);
         return subject.Grades;
     }
