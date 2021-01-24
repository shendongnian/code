    string fullQuestion = string.Empty;
    
    if (Data.Questions.Sum.wordedQuestions != null &&
        Data.Questions.Sum.wordedQuestions.Length > 0)
    {
        //here the way you are creating random number, 
        // you are assured about index is present in array.
        int indexForWordedQuestion = rnd.Next(0, Data.Questions.Sum.wordedQuestions.Length);
        fullQuestion = Data.Questions.Sum.wordedQuestions[indexForWordedQuestion];
    }
