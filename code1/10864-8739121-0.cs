    private static readonly string _Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static int ColumnNameParse(string value)
    {
        // assumes value.Length is [1,3]
        // assumes value is uppercase
        var digits = value.PadLeft(3).Select(x => _Alphabet.IndexOf(x));
        return digits.Aggregate(0, (current, index) => (current * 26) + (index + 1));
    }
