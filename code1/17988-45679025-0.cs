    private static int GetSnippetStartPoint(string documentText, string originalQuery, int snippetLength)
    {
        // Normalise document text
        documentText = documentText.Trim();
        if (string.IsNullOrWhiteSpace(documentText)) return 0;
        // Return 0 if entire doc fits in snippet
        if (documentText.Length <= snippetLength) return 0;
        // Break query down into words
        var wordsInQuery = new HashSet<string>();
        {
            var queryWords = originalQuery.Split(' ');
            foreach (var word in queryWords)
            {
                var normalisedWord = word.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(normalisedWord)) continue;
                if (wordsInQuery.Contains(normalisedWord)) continue;
                wordsInQuery.Add(normalisedWord);
            }
        }
        // Create moving window to get maximum trues
        var windowStart = 0;
        double maxScore = 0;
        var maxWindowStart = 0;
        // Higher number less accurate but faster
        const int resolution = 5;
        while (true)
        {
            var text = documentText.Substring(windowStart, snippetLength);
            // Get score of this chunk
            // This isn't perfect, as window moves in steps of resolution first and last words will be partial.
            // Could probably be improved to iterate words and not characters.
            var words = text.Split(' ').Select(c => c.Trim().ToLower());
            double score = 0;
            foreach (var word in words)
            {
                if (wordsInQuery.Contains(word))
                {
                    // The longer the word, the more important.
                    // Can simply replace with score += 1 for simpler model.
                    score += Math.Pow(word.Length, 2);
                }                   
            }
            if (score > maxScore)
            {
                maxScore = score;
                maxWindowStart = windowStart;
            }
            // Setup next iteration
            windowStart += resolution;
            // Window end passed document end
            if (windowStart + snippetLength >= documentText.Length)
            {
                break;
            }
        }
        return maxWindowStart;
    }
