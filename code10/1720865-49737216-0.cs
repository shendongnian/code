    public char GetQuestionRef(string question, string answer)
    {
        string[] answers = question.Split('\n');
        char question; 
        for(int i = 1; i < answers.Length; i++)
        {
            if(answers[i].Contains(answer))
            {
                question = answers[i].Substring(0, 1);              
            }
        }
        return question;
    }
