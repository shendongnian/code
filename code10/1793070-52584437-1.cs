    public static class TextExtensions
    {
        public static IEnumerable<string> TextElements(this string s)
        {
            // StringInfo.GetTextElementEnumerator is a .Net 1.1 class that doesn't implement IEnumerable<string>, so convert
            if (s == null)
                yield break;
            var enumerator = StringInfo.GetTextElementEnumerator(s);
            while (enumerator.MoveNext())
                yield return enumerator.GetTextElement();
        }
    }
