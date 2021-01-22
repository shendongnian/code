    public static IEnumerable<string> SplitByLength(this string str, int maxLength) {
        int index = 0;
        while(true) {
            if (index + maxLength >= str.Length) {
                yield return str.Substring(index);
                yield break;
            }
            yield return str.Substring(index, maxLength);
            index += maxLength;
        }
    }
