    class Program
    {
        static void Main(string[] args)
        {
            var q1 = new Question("What colour is the sky?", new string[] { "Pink", "Blue", "Purple", "Yellow" }, "multipleChoice", 1);
            AskQuestion(q1);
        }
        private static void AskQuestion(Question q)
        {
            Console.WriteLine(q.Prompt);
            for (var i = 0; i < q.AnswersList.Length; i++)
            {
                Console.WriteLine($"{Convert.ToChar(65 + i)} - {q.AnswersList[i]}");
            }
            var answer = Console.ReadKey(true);
            if (answer.KeyChar == 65 + q.CorrectAnswer ||
                answer.KeyChar == 97 + q.CorrectAnswer)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Wrong");
            }
        }
        private class Question
        {
            public string Prompt { get; }
            public string[] AnswersList { get;  }
            public string TypeOfQuestion { get; }
            public int CorrectAnswer { get;  }
            public Question(string prompt, string[] answersList, string typeOfQuestion, int correctAnswer)
            {
                this.Prompt = prompt;
                this.AnswersList = answersList;
                this.TypeOfQuestion = typeOfQuestion;
                this.CorrectAnswer = correctAnswer;
            }
        }
    }
