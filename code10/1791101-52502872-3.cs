    public class QuizItem
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public List<string> Choices { get; set; }
        public int CorrectChoiceIndex { get; set; }
        public string UserResponse { get; private set; }
        public bool Result { get; private set; }
        public bool AskQuestion()
        {
            Console.WriteLine(Question);
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
            int choice;
            do
            {
                Console.Write($"Enter response (1 - {Choices.Count}):");
            } while (!int.TryParse(Console.ReadLine(), out choice) ||
                        choice < 1 || choice > Choices.Count + 1);
            Result = choice - 1 == CorrectChoiceIndex;
            UserResponse = Choices[choice - 1];
            Console.WriteLine(Result ? "Correct!" : "Incorrect.");
            Console.WriteLine();
            return Result;
        }
    }
