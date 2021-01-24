    string fullQuestion = string.Empty;
    int indexForWordedQuestion = rnd.Next(0, Data.Questions.Sum.wordedQuestions.Length);
    if (Data.Questions.Sum.wordedQuestions != null &&
        Data.Questions.Sum.wordedQuestions.Length > indexForWordedQuestion)
    {
        fullQuestion = Data.Questions.Sum.wordedQuestions[indexForWordedQuestion];
    }
