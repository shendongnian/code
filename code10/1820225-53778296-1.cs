    public IEnumarable<ExcelExport> GetExcelExports()
    {
        return _context.Articles.Select(a => new ExcelExport
        {
           ArticleTitle = a.ArticleTitle,
           NumberOfComment = a.NumberOfComment,
           NumberOfReviews = a.NumberOfView,
           Reviewer1Point = a.Reviews.Any(e => e.ReviewerId = 1) ? a.Reviews.Where(e => e.ReviewerId = 1).Sum(e => e.ReviewPoint) : 0,
           Reviewer2Point = a.Reviews.Any(e => e.ReviewerId = 2) ? a.Reviews.Where(e => e.ReviewerId = 2).Sum(e => e.ReviewPoint) : 0,
           ....
           ReviewerNPoint = a.Reviews.Any(e => e.ReviewerId = N) ? a.Reviews.Where(e => e.ReviewerId = N).Sum(e => e.ReviewPoint) : 0
         });
    }
