    public static string ReplaceFirst(this string original, string oldValue, string newValue)
    {
        var index = original.IndexOf(oldValue);
        if (index >= 0) {
            var prev = original.Substring(0, index);
            var after = original.Substring(index + oldValue.Length);
            return prev + newValue + after;
        }
        return original;
    }
