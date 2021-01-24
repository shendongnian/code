    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>(); 
        }
        SetCurrentQuestion();
       foreach(Question currentQuestion in unansweredQuestions)
       {
          //do something with the currentQuestion
       }
    }
