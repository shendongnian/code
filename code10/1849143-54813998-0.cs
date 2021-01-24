    private static readonly Dictionary<string, int> _errorCodeScores = new Dictionary<string, int>
    {
        { "@", 1 },
        { "-2", -2 },
        { "!", 5 },
    };
    private static int Score(string[] errorCodes)
    {
        return _errorCodeScores
            .Where(s => errorCodes.Any(c => s.Key == c))
            .Sum(s => s.Value);
    }
