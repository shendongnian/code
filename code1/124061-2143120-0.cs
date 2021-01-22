    static string TrimTrailingZeros(string s) {
        return s.Trim(new[] { '0' });
    }
    static bool TryParseAfterTrim(string s, out decimal d) {
        return Decimal.TryParse(TrimTrailingZeros(s), out d);
    }
