    public class QuizItem
    {
        public string Question { get; set; }
        public List<string> PossibleAnswers { get; set; }
        public bool DisplayCorrectAnswerImmediately { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public bool AskQuestionAndGetResponse()
        {
            Console.WriteLine(Question + Environment.NewLine);
            for (int i = 0; i < PossibleAnswers.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {PossibleAnswers[i]}");
            }
            int response = GetIntFromUser($"\nEnter answer (1 - {PossibleAnswers.Count}): ",
                1, PossibleAnswers.Count);
            if (DisplayCorrectAnswerImmediately)
            {
                if (response == CorrectAnswerIndex + 1)
                {
                    Console.WriteLine("\nThat's correct, good job!");
                }
                else
                {
                    Console.WriteLine("\nSorry, the correct answer is: {0}",
                        $"{CorrectAnswerIndex + 1}. {PossibleAnswers[CorrectAnswerIndex]}");
                }
            }
            return response == CorrectAnswerIndex + 1;
        }
        // This helper method gets an integer from the user within the specified bounds
        private int GetIntFromUser(string prompt, int min, int max)
        {
            int response;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out response) ||
                     response < min || response > max);
            return response;
        }
    }
