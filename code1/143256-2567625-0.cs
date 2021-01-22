    using System.Globalization;
    ...
        private static IEnumerable<string> GetAllCharacters(string text)
        {
            TextElementEnumerator elementEnumerator = StringInfo.GetTextElementEnumerator(text);
            while (elementEnumerator.MoveNext())
                yield return (string)elementEnumerator.Current;
        }
