    public void OnGet()
    {
        Helper helper = new Helper(_logger, _context);
        var Test = helper.GetTestString();
        var saltyList = helper.GetAllApples();
        Input = new InputModel
                {   
                    QuestionList = questionList
                };
    }
