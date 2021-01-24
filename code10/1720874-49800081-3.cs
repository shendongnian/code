    private static void Main()
    {
        Console.Write("Please enter your name: ");
        var userName = Console.ReadLine();
        var quiz = new Quiz(new User(userName));
        PopulateQuizItems(quiz);          
        quiz.BeginTest();
        GetKeyFromUser("\nDone!! Press any key to exit...");
    }
