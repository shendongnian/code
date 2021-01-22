    public static IEnumerable<string> SplitByLength(this string str, int maxLength) {
        if (str.Length <= maxLength) {
            yield return str;
            yield break;
        }
        for (int index = 0; index < str.Length; index += maxLength) {
            yield return str.Substring(index, Math.Min(maxLength, str.Length - index));
        }
    }
