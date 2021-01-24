     public class GetCalculatePerform
        {
    
     abcEntities dbcontext = new abcEntities();
    
            public UserRankObject tempobj { get; set; }
    
    
            //********************************************************Performance & Rank Calculation********************************************
    
    
          public  GetCalculatePerform(int? Student_ID, int? CourseID, int? SemID, int? SubjectID)
            {
               
                
                    var scoreCard = dbcontext.Stu_Result
                    .Where(u => u.CourseID == CourseID && u.SemID == SemID && u.SubjectID == SubjectID)
                    .ToList()
                    .GroupBy(u => u.UserID)
                    .OrderByDescending(grp => grp.Average(u => u.ScoredMarks))
                    .Select((grp, i) => new UserRankObject
                    {
                        UserId = grp.Key,
                        Rank = i + 1,
                        AverageScore = grp.Average(u => u.ScoredMarks)
                    }).ToList().Single(u => u.UserId == Student_ID);
                    // .FirstOrDefault(u=>u.UserId == Student_ID);
    
    
                    this.tempobj = scoreCard;
                
                  
          }
            
        }
