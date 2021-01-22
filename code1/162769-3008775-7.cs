    public static IEnumerable<string> SplitByLength(this string str, int maxLength) {
        int index = 0;
        while(index + maxLength <= str.Length) {
            yield return str.Substring(index, maxLength);
            index += maxLength;
        }
        yield return str.Substring(index);
    }
