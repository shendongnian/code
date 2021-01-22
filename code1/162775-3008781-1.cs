    public static IEnumerable<string> EnumerateByLength(this string text, int length) {
        int index = 0;
        while (index < text.Length) {
            int charCount = Math.Min(length, text.Length - index);
            yield return text.Substring(index, charCount);
            index += length;
        }
    }
