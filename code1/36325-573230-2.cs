    var questions = new List<Question>();
    
    using (var quizFileReader = new System.IO.StreamReader("questions.txt"))
    {
        string line;
        Question question;
        int answer;
    
        while ((line = quizFileReader.ReadLine()) != null)
        {
            if (line.Length == 0)
                continue;
    
            answer = -1;
            question = (new Question()
            {
                QuestionText = line,
                Choices = ((new string[] { 
                    quizFileReader.ReadLine(), quizFileReader.ReadLine(),
                    quizFileReader.ReadLine(), quizFileReader.ReadLine()}).Select((choice, index) =>
                    {
                        var isAnswer = choice.StartsWith(":");
                        if (isAnswer) answer = index;
                        return isAnswer ? choice.Substring(1) : choice;
                    })).ToArray(),
                Answer = answer
            });
            if (answer == -1)
            {
                throw new InvalidOperationException(
                    "Correct answer was not specified for the following question.\r\n\r\n" +
                    question.QuestionText);
            }
            questions.Add(question);
        }
    }
