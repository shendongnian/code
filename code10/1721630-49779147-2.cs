    private static void Main()
    {
        var testSentenceLists = GetTestSentences();
        var padLength = testSentenceLists.Max(t => t.Max(s => s.Length)) + 2;
        Console.WriteLine("\nComparison Results\n------------------\n");
        // Rufus' solution
        var sw = Stopwatch.StartNew();
        foreach (var testSentenceList in testSentenceLists)
        {
            var trimmedSentences = RemoveCommonPrefixAndSuffix(testSentenceList);
            for(var j = 0; j < trimmedSentences.Count; j++)
            {
                Console.WriteLine($"{testSentenceList[j].PadRight(padLength, '.')} {trimmedSentences[j]}");
            }
            Console.WriteLine();
        }
        sw.Stop();
        Console.WriteLine($"Rufus' solution took {sw.ElapsedMilliseconds} ms\n");
        Console.WriteLine(new string('-', Console.WindowWidth));
        // Prateek's solution
        sw.Restart();
        foreach (var testSentenceList in testSentenceLists)
        {
            var prefix = FindMatchingPattern(testSentenceList[0], testSentenceList[1], true);
            var suffix = FindMatchingPattern(testSentenceList[0], testSentenceList[1], false);
            if (prefix.Length > 0) prefix = Regex.Escape(prefix);
            if (suffix.Length > 0) suffix = Regex.Escape(suffix);
            foreach (var item in testSentenceList)
            {
                var result = Regex.Replace(item, prefix, string.Empty);
                result = Regex.Replace(result, suffix, string.Empty);
                Console.WriteLine($"{item.PadRight(padLength, '.')} {result}");
            }
            Console.WriteLine();
        }
        sw.Stop();
        Console.WriteLine($"Prateek's solution took {sw.ElapsedMilliseconds} ms\n");
        Console.WriteLine(new string('-', Console.WindowWidth));
        GetKeyFromUser("\nDone!! Press any key to exit...");
    }
