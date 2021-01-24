    private static string GetReplacementValue(Dictionary<string, string> replacementValues, string message)
    {
        string processedMessage = message;
        foreach (var item in replacementValues)
        {
            processedMessage = processedMessage.Replace(item.Key, item.Value);
        }
        return processedMessage;
    }
