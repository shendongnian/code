    public static int[] GetErrorIndices(string text) {
        if (string.IsNullOrEmpty(text))
            return new int[0];
        List<int> errorIndices = new List<int>();
        int i = 0;
        while (i < text.Length) {
            char c = text[i];
            // get the index of the next character that isn't a repetition
            int nextIndex = i + 1;
            while (nextIndex < text.Length && text[nextIndex] == c)
                nextIndex++;
            // if we've reached the end of the string, there's no error
            if (nextIndex + 1 >= text.Length)
                break;
            // we actually only care about text[nextIndex + 1],
            // NOT text[nextIndex] ... why? because text[nextIndex]
            // CAN'T be a repetition (we already skipped to the first
            // non-repetition)
            if (text[nextIndex + 1] == c)
                errorIndices.Add(i);
            i = nextIndex;
        }
        return errorIndices.ToArray();
    }
