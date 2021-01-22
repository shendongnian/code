    // Give it a proper name really :)
    public class IndexComparer : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            // I'll leave you to decide what to do if the format is wrong
            int firstIndex = GetIndex(first);
            int secondIndex = GetIndex(second);
            return firstIndex.CompareTo(secondIndex);
        }
        private static int GetIndex(string text)
        {
            int pipeIndex = text.IndexOf('|');
            return int.Parse(text.Substring(0, pipeIndex));
        }
    }
