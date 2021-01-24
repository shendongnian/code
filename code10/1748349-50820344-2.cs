    private static void Main()
    {            
        // Get the current date and time
        var now = DateTime.Now;
        // Build our greeting string
        var greeting = new StringBuilder();
        greeting.Append("Good " + GetGeneralTime(now) + "! ");
        greeting.AppendLine("Today's date: " + now.ToString("MMMM dd, yyyy, dddd. "));
        greeting.AppendLine("Now you have to concentrate on " + GetConcentrationDays(now));
        // Display our greeting to the user
        Console.WriteLine(greeting.ToString());
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
