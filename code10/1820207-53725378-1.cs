    public List<ExcelExport> GetExcelExports()
    {
        return _context.Articles.Select(a => new ExcelExport
        {
            ArticleTitle = a.ArticleTitle,
            NumberOfComment = a.NumberOfComment,
            NumberOfReviews = a.NumberOfView,
            Reviews = a.Reviews.Select(r => new ArticleReviewReport
            {
                Reviewer = r.ReviewerId,
                ReviewPoint = r.ReviewPoint
            }).ToList()
        }).ToList();
    }
