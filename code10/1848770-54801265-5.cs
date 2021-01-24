    public class UserRankObject
    {
        public int Rank { get; set; }
        public int UserId { get; set; }
        public float AverageScore { get; set; }
    }
    public UserRankObject GetUserRankObject(int? Student_ID, int? CourseID, int? SemID, int? SubjectID)
    {
        // TODO: add null checks for arguments, or make them non-nullable.
        var scoreCard =
            dbcontext.Stu_Result
                .Where(u => u.CourseID == CourseID
                         && u.SemID == SemID
                         && u.SubjectID == SubjectID);
        return scoreCard.GroupBy(u => u.UserID)
           .OrderByDescending(g => g.Average(u => u.ScoredMarks / u.TotalMarks * 100))
           .Select((g, i) => new UserRankObject
           {
               UserId = g.Key,
               Rank = i + 1,
               AverageScore = g.Average(u => u.ScoredMarks / u.TotalMarks * 100)
           })
           .Single(u => u.UserId == Student_ID);
    }
