    private static string ToFixedWidths(string s, char separator, List<int> widths)
    {
        List<string> split = s.Split(separator).ToList();
        return string.Join(String.Empty, split.Select((ss, i) => PadString(ss, widths[i])).ToArray());
    }
    private static string PadString(string s, int width)
    {
        // TODO: Pad the string
    }
