    private static void Main()
    {
        var testInput = new List<string>
        {
            null,
            "",
            "       ",
            "Normal sentence test.",
            "Test with spaces   .",
            "Test with multiple ending chars  !?!?!",
            "Test with only spaces at end   ",
            "Test with spaces after punctuation.   ",
            "Test with mixed punctuation and spaces ! ? ! ? ! "
        };
        foreach (var test in testInput)
        {
            // Format output so we can "see" null and empty strings
            var original = test ?? "<null>";
            if (original.Length == 0) original = "<empty>";
            // Show original and the result. Wrap result in <> so we know where it ends.
            Console.WriteLine($"{original.PadRight(50, '-')} = <{TrimEndSpaces(test)}>");
        }
            
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
