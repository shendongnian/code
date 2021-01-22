    static string TrimZeros(string s) {
        return s.Trim(new[] { '0' });
    }
    static bool TryParseAfterTrim(string s, out decimal d) {
        return Decimal.TryParse(TrimZeros(s), out d);
    }
