    class Program
    {
        static void Main()
        {
            const int numberOfMarks = 5;
            int[] marks = new int[numberOfMarks];
            int intTemp;
            Console.WriteLine("Enter 5 elements:");
            for (int a = 0; a < numberOfMarks; a++)
            {
                // If entered character not a number, give a chance to try again till number not entered
                while(!int.TryParse(Console.ReadLine(), out intTemp))
                {
                    Console.WriteLine("Entered not a character");
                }
                Console.WriteLine("You entered : " + intTemp);
                marks[a] = intTemp;
            }
            // Have to call Average only once.
            var avg = marks.Average();
            Console.WriteLine(avg > 0 ? "Positive average" : "Negative average");
            Console.ReadLine();
        }
    }
