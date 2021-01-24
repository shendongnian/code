    static void Main()
    {
        Random rnd = new Random();
        // Populate a list of 30 random numbers from 1 to 100
        var randomNumbers = Enumerable.Range(0, 30)
            .Select(i => rnd.Next(1, 101)).ToList();
        // Output our numbers to the console as column headers
        randomNumbers.ForEach(n =>
            Console.Write(n.ToString().PadLeft(3)));
        // Set the next cursor line as the top of the grid
        var topOfGrid = Console.CursorTop + 1;
        // For each number, divide by 10 and output the result to the console
        for(int rndIndex = 0; rndIndex < randomNumbers.Count; rndIndex++)
        {
            // Capture the left for this column. We multiply the 
            // current index by 3 because we're spacing the columns 
            // 3 characters wide. Then add one so it prints 
            // in the middle of the column
            var columnLeft = 3 * rndIndex + 1;
            var result = randomNumbers[rndIndex] / 10;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(columnLeft, topOfGrid + i);
                // Determine which character to write by comparing
                // our number with the value of 10 - i
                Console.Write(result >= 10 - i ? "*" : " ");
            }
        }           
        Console.WriteLine();
        Console.ReadLine();
        GetKeyFromUser("\nPress any key to exit...");
    }
