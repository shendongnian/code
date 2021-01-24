        public GetCalculatePerform(int? Student_ID, int? CourseID, int? SemID, int? SubjectID)
        {           
            var scoreCard = dbcontext.Stu_Result
            .Where(u => u.CourseID == CourseID && u.SemID == SemID && u.SubjectID == SubjectID )
            .ToList()
            .GroupBy(u => u.UserID)
            .OrderByDescending(grp => grp.Average(u => u.ScoredMarks))
            .Select((grp, i) => new
            {
                UserId = grp.Key,
                Rank = i + 1,
                AverageScore = grp.Average(u => u.ScoredMarks)
            }).ToList().Single(u => u.UserId == Student_ID);
}
