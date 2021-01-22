    public class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            Match xMatch = Regex.Match(x, @"^(\D*)(\d+)$");
            Match yMatch = Regex.Match(y, @"^(\D*)(\d+)$");
            string xChars = xMatch.Groups[1].Value;
            string yChars = yMatch.Groups[1].Value;
            if ((xChars.Length == 0) && (yChars.Length > 0))
            {
                return 1;
            }
            else if ((xChars.Length > 0) && (yChars.Length == 0))
            {
                return -1;
            }
            else
            {
                int charsResult = xChars.CompareTo(yChars);
                return (charsResult != 0)
                    ? charsResult
                    : int.Parse(xMatch.Groups[2].Value)
                        .CompareTo(int.Parse(yMatch.Groups[2].Value));
            }
        }
    }
