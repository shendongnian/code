    static void Main(string[] args)
    {
        var validResponses = new List<string> {"Yes", "No"};
        var userInput = GetUserInput("Do you like me? ", validResponses);
        if (userInput.Equals("Yes", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("I like you too!");
        }
        else
        {
            Console.WriteLine("And all along I thought you had good taste.");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
