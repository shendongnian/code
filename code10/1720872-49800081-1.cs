    public class Quiz
    {
        public Quiz(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            User = user;
            QuizItems = new List<QuizItem>();
        }
        public List<QuizItem> QuizItems { get; set; }
        public User User { get; set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public void BeginTest()
        {
            Console.Clear();
            if (QuizItems == null)
            {
                Console.WriteLine("There are no quiz items available at this time.");
                return;
            }
            Console.WriteLine($"Welcome, {User.Name}! Your quiz will begin when you press a key.");
            Console.WriteLine($"There are {QuizItems.Count} multiple choice questions. Good luck!\n");
            Console.Write("Press any key to begin (or 'Q' to quit)...");
            if (Console.ReadKey().Key == ConsoleKey.Q) return;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            var itemNumber = 1;
            StartTime = DateTime.Now;
            foreach (var item in QuizItems)
            {
                Console.WriteLine($"Question #{itemNumber}");
                Console.WriteLine("-------------");
                itemNumber++;
                var result = item.AskQuestionAndGetResponse();
                User.QuestionsAnswered++;
                if (result) User.CorrectAnswers++;
            }
            EndTime = DateTime.Now;
            var quizTime = EndTime - StartTime;
            Console.WriteLine("\nThat was the last question. You completed the quiz in {0}",
                $"{quizTime.Minutes} minues, {quizTime.Seconds} seconds.");
            Console.WriteLine("\nYou answered {0} out of {1} questions correctly, for a grade of '{2}'",
                User.CorrectAnswers, User.QuestionsAnswered, User.LetterGrade);
        }
    }
