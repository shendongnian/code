    private static readonly Regex numTextSplitRegex =
        new Regex(@"(?<=\D)(?=\d)|(?<=\d)(?=\D)", RegexOptions.Compiled);
    public int Compare(string x, string y)
    {
        x = x ?? "";
        y = y ?? "";
        string[] xParts = numTextSplitRegex.Split(x);
        string[] yParts = numTextSplitRegex.Split(y);
        bool firstXIsNumber = xParts[0].Length > 0 && Char.IsDigit(xParts[0][0]);
        bool firstYIsNumber = yParts[0].Length > 0 && Char.IsDigit(yParts[0][0]);
        if (firstXIsNumber != firstYIsNumber) {
            return x.CompareTo(y);
        }
        for (int i = 0; i < Math.Min(xParts.Length, yParts.Length); i++) {
            int result;
            if (firstXIsNumber == (i % 2 == 0)) { // Compare numbers.
                long a = Int64.Parse(xParts[i]);
                long b = Int64.Parse(yParts[i]);
                result = a.CompareTo(b);
            } else { // Compare texts.
                result = xParts[i].CompareTo(yParts[i]);
            }
            if (result != 0) {
                return result;
            }
        }
        return xParts.Length.CompareTo(yParts.Length);
    }
