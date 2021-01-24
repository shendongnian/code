    namespace ConsoleApp1
    {
         class Program
         {
          static void Main(string[] args)
          {
            // TODO: Ask the user how many high scores they want.
            //       Then read in their input.
            //       Support error checking (input validation).
            //       The user should only be able to input a positive
            //       integer value.
            Console.WriteLine("Input count of total scores.");
            string size = Console.ReadLine();
            while (!int.TryParse(size, out int k))
            {
                Console.WriteLine("Invalid.");
                size = Console.ReadLine();
            }
            // TODO: Define an array of ints, which will hold the high scores.
            //       Make the array the exact size indicated by the user above.
            int i = Convert.ToInt32(size);
            int[] score = new int[i];
            // TODO: Ask the user for each high score, and read in their inputs.
            //       Make sure to read in as many high scores are in the array.
            //       If the high score array is size 5, then read in 5 inputs.
            //       You DO NOT NEED to support error checking for each score;
            //       assume each input will be an integer.
            Console.WriteLine("Please input test score from 0 to 100.");
            for (int j = 0; j < score.Length; j++)
            {
                score[j] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine("High Scores - Unsorted");
            // TODO: Call your PrintArray function passing the array of high scores.
            int[] userScores = new int[i];
            for (int d = 0; d < score.Length; d++)
            {
                Console.WriteLine(score[d]);
            }
            // TODO: Call the SortArrayHighToLow procedure,
            //       passing the array of high scores, to sort them.
            // Liao fix from here
            int[] sortedScores = new int[i];
            for (int j = 0; j < score.Length; j++)
            {
                sortedScores[j] = score[j] ;
            }
            Console.WriteLine("break, show unsofted score on array softedscore");
            foreach (int element in sortedScores)
            {
                Console.WriteLine(element);
            }
            SortArrayHighToLow(sortedScores);
            Console.WriteLine("break, show userscore");
            foreach (int element in userScores)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("Highest Score");
            Console.WriteLine(sortedScores[0]);
            // TODO: Uncomment the following lines
            Console.WriteLine();
            Console.WriteLine("High Scores - Sorted");
            // TODO: Call your PrintArray function passing the array of high scores.
            foreach (int element in sortedScores)
            {
                Console.WriteLine(element);
            }
            // liao end here
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        }
        // TODO: Write a function called PrintArray that takes as input
        //       a single int array, and returns nothing.
        //       The function will loop through the array and print out
        //       each int on its own line.
        //       Don't forget the keyword static.
        public static void PrintArray(int[] numbers)
        {
            foreach (int x in numbers)
            {
                Console.Write(x);
            }
            numbers = null;
        }
        /// <summary>
        /// This procedure takes an array of ints and sorts them in place.
        /// After a call to this procedure the array of ints passed in will be
        /// sorted from highest to lowest.
        /// </summary>
        /// <param name="numbers">an array of ints to sort</param>
        static void SortArrayHighToLow(int[] numbers)
        {
            int tmp;
            for (int i = 1; i < numbers.Length; i++)
            {
                for (int j = i; j > 0 && numbers[j] > numbers[j - 1]; j--)
                {
                    tmp = numbers[j];
                    numbers[j] = numbers[j - 1];
                    numbers[j - 1] = tmp;
                }
            }
        }
    }
}
