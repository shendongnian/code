    private static void Main()
    {
        // Output our random colors. Note that even though we
        // only we only have 6 colors, they are consistently 
        // output in a random order (but with no duplicates).
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine(GetNextColoredBrush().Color.ToKnownColor());
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
