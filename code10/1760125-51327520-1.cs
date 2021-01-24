     public class StudentScores
     {
         public string Name { get; set;}
         public string TotalScore {get; set; }
     }
     var results = dbContext.Students.AsNoTracking().Where(s => s.IsStudentEnabled 
                                                 && s.IsEnrolledAllSubjects)
                    .OrderBy(x => x.studentFirstName).ThenBy(x => x.totalScore)
                    .Select(x => new StudentScores { 
                                           Name = x.studentFirstName,
                                           TotalScore = x.totalScore
                    }).ToList();
  
