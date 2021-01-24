    private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string ToExcelCoordinates(string coordinates)
    {
        string first = coordinates.Substring(0, coordinates.IndexOf(','));
        int i = int.Parse(first);
        string second = coordinates.Substring(first.Length + 1);
        string str = string.Empty;
        while (i > 0)
        {
            str = ALPHABET[(i - 1) % 26] + str;
            i /= 26;
        }
        return str + second;
    }
    public static string ToNumericCoordinates(string coordinates)
    {
        string first = string.Empty;
        string second = string.Empty;
        CharEnumerator ce = coordinates.GetEnumerator();
        while (ce.MoveNext())
            if (char.IsLetter(ce.Current))
                first += ce.Current;
            else
                second += ce.Current;
        int i = 0;
        ce = first.GetEnumerator();
        while (ce.MoveNext())
            i = (26 * i) + ALPHABET.IndexOf(ce.Current) + 1;
        string str = i.ToString();
        return str + "," + second;
    }
