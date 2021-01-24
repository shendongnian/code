    public ActionResult Questions()
    {
      var questions = _laraTestEntities.Questions.ToList();
      var questionModel = new List<QuestionModel>();
    
      questions.ForEach(q =>
      {
    
        var subQuestions = _laraTestEntities.SubQuestions.Where(s => s.ParentQuestionId == q.Id).ToList();
        var options = _laraTestEntities.Options.ToList();
    
        var model = new QuestionModel
        {
          Id = q.Id,
          Question = q.Question1,
          SubQuestions = subQuestions,
          Options = options
        };
    
        questionModel.Add(model);
      });
      return View(questionModel);
    }
    
    [HttpPost]
    public ActionResult Questions(List<QuestionModel> Model)
    {
      Model.ForEach(q =>
      {
        var questionDetail = _laraTestEntities.Questions.Find(q.Id);
        if (questionDetail != null)
        {
          questionDetail.Question1 = q.Question;
          q.SubQuestions.ForEach(s =>
          {
            var subQuestionDetail = _laraTestEntities.SubQuestions.Find(s.Id);
            if (subQuestionDetail != null)
            {
              subQuestionDetail.SubQuestion1 = s.SubQuestion1;
            }
          });
    
          _laraTestEntities.SaveChanges();
    
        }
      });
      
      return View(Model);
    }
