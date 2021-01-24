    private static void Main()
    {
        // Used to store the last result (starting with null value)
        double? lastResult = null;
        // Iterates 1000 times (from 1 to 1000 inclusive)
        for (int value = 1; value <= 1000; value++)
        {
            double result = Math.Pow(value, 2) - 100 * value + 900;
            if (lastResult != null)
            {
                if (lastResult < 0 && result >= 0)
                {
                    Console.WriteLine(
                        $"Sign changed from negative to positive when the value became '{value}'");
                }
                else if (lastResult >= 0 && result < 0)
                {
                    Console.WriteLine(
                        $"Sign changed from positive to negative when the value became '{value}'");
                }
            }
            lastResult = result;
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
