    private static int GetIntFromUser(string prompt, Func<int, bool> validator = null)
    {
        int result = 0;
        bool answeredCorrectly = false;
        while (!answeredCorrectly)
        {
            // Show message to user
            Console.Write(prompt);
            // Set to true only if int.TryParse succeeds and the validator returns true
            answeredCorrectly = int.TryParse(Console.ReadLine(), out result) &&
                                (validator == null || validator.Invoke(result));
            if (!answeredCorrectly) Console.WriteLine("Incorrect, please try again");
        }
        return result;
    }
