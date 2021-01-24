    private static void PopulateQuizItems(Quiz quiz)
    {
        if (quiz == null) return;
        quiz.QuizItems.Add(new QuizItem
        {
            Question = "What does the word 'virile' mean?",
            PossibleAnswers = new List<string>
            {
                "Like a rabbit",
                "Like a man",
                "Like a wolf",
                "Like a horse"
            },
            CorrectAnswerIndex = 1,
            DisplayCorrectAnswerImmediately = true
        });
    }
