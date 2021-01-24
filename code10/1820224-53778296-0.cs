    public IEnumarable<ExcelExport> GetExcelExports()
    {
        return _context.Articles.Select(a => new ExcelExport
        {
           ArticleTitle = a.ArticleTitle,
           NumberOfComment = a.NumberOfComment,
           NumberOfReviews = a.NumberOfView,
           Reviewer1Point = a.Reviews.Where(e => e.ReviewerId = 1).Sum(e => e.ReviewPoint),
           Reviewer2Point = a.Reviews.Where(e => e.ReviewerId = 2).Sum(e => e.ReviewPoint),
           ....
           ReviewerNPoint = a.Reviews.Where(e => e.ReviewerId = N).Sum(e => e.ReviewPoint)
         });
    }
