    [HttpGet("/questions")]
    public ActionResult<List<QuestionDetails>> GetQuestions()
    {
        return _quizService.GetAllQuestions()
            .Select(x => new QuestionDetails
            {
                Id = x.Id,
                Question = x.QuestionQuiz,
                ImageName = x.ImageName,
                Options = new [] { x.Option1, x.Option2, x.Option3, x.Option4 }
                    .Where(option => !string.IsNullOrEmpty(option))
            })
            .OrderBy(y => Guid.NewGuid())
            .Take(10)
            .ToList();
    }
