    List<string> myStrings;
    myStrings.Sort(LevenshteinCompare);
    ...
    public class LevenshteinCompare: IComparer<string>
    {
        public int Compare(string x, string y)
        {
            // Magic goes here
        }
    }
