    var byIdTask = 
        db.Question.Where(question => question.Id == questionId).ToListAsync();
    var relatedTask = 
        db.Question.Where(question => question.RelatedId = questionId)
                                    .Where(question => question.IsAccept == isAccept)
                                    .ToListAsync();
    await Task.WhenAll(new[] byIdTask, relatedTask);
    var allQuestions = byIdTask.Result.Concat(relatedTask.Result).ToList();
