    public List<string> HighLightedParagraphs(string word, string text)
    {
        int charBeforeAndAfter = 100;
        List<string> matchParagraphs = new List<string>();
        Regex wordMatch = new Regex(@"\b" + word + @"\b", RegexOptions.IgnoreCase);
        foreach (string paragraph in text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            int startIdx = -1;
            int length = -1;
            foreach (Match match in wordMatch.Matches(paragraph))
            {
                int wordIdx = match.Index;
                if (wordIdx >= startIdx && wordIdx <= startIdx + length) continue;
                startIdx = wordIdx > charBeforeAndAfter ? wordIdx - charBeforeAndAfter : 0;
                length = wordIdx + match.Length + charBeforeAndAfter < paragraph.Length
                                    ? match.Length + charBeforeAndAfter
                                    : paragraph.Length - startIdx;
                string extract = wordMatch.Replace(paragraph.Substring(startIdx, length), "<b>" + match.Value + "</b>");
                matchParagraphs.Add("..." + extract + "...");
            }
        }
        return matchParagraphs;
    }
