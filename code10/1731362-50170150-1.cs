    class Program
    {
        static void Main()
        {
            const int numberOfMarks = 5;
            int[] marks = new int[numberOfMarks];
            Console.WriteLine("Enter 5 elements:");
            for (int a = 0; a < numberOfMarks; a++)
            {
                // If entered character not a number, give a chance to try again till number not entered
                while(!int.TryParse(Console.ReadLine(), out marks[a]))
                {
                    Console.WriteLine("Entered not a character");
                }
                Console.WriteLine("You entered : " + marks[a]);
            }
            // Have to call Average only once.
            var avg = marks.Average();
            Console.WriteLine(avg > 0 ? "Positive average" : "Negative average");
            Console.ReadLine();
        }
    }
