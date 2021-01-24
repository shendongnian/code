    static void Main()
    {
        DateTime peakStartDate = new DateTime(2018, 6, 15);
        DateTime peakEndDate = new DateTime(2018, 8, 15);
        Console.Write("Please Enter the number of people: ");
        // Use TryParse to get an integer from the user. If TryParse fails,
        // it means they entered an invalid value, so ask them to do it again.
        // Otherwise, numPeople will hold the integer value they entered
        int numPeople;
        while (!int.TryParse(Console.ReadLine(), out numPeople))
        {
            Console.WriteLine("Error: input was not a whole number.\n");
            Console.Write("Please Enter the number of people: ");
        }
        double flightPrice = 238 * numPeople;
        // Get the arrival date from the user
        Console.Write("\nPlease enter the arrival date (dd-MM-yyyy): ");
        DateTime firstDate;
        // If TryParseExact fails, they entered an incorrect format, so we
        // keep asking them. If it succeeds, then firstDate will hold the value.
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy",
            CultureInfo.CurrentCulture, DateTimeStyles.None, out firstDate))
        {
            Console.WriteLine("Error: input was not in correct format\n");
            Console.Write("Please enter the arrival date (dd-MM-yyyy): ");
        }
        // Same process for departure date
        Console.Write("\nPlease enter the departure date (dd-MM-yyyy):");
        DateTime secondDate;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy",
            CultureInfo.CurrentCulture, DateTimeStyles.None, out secondDate))
        {
            Console.WriteLine("Error: input was not in correct format");
            Console.Write("\nPlease enter the departure date (dd-MM-yyyy): ");
        }
        // If they're travelling during the peak period, increase the price
        if (firstDate >= peakStartDate && secondDate <= peakEndDate)
        {
            flightPrice *= 1.2;
        }
        Console.ReadLine();
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
