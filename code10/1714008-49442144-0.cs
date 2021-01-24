    public static void playAgainn()
    {
        Console.WriteLine("Do you want to play again?(y/n)");
        string loop = Console.ReadLine();
        if (loop == "y")
        {
            playAgain = true;
            // reset scores here
            Console.Clear();
        }
        else if (loop == "n")
        {
            playAgain = false;
        }
        else
        {
        }
    }
