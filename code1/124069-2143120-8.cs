    static char[] whitespaceAndZero = new[] {
        ' ',
        '\t',
        '\r',
        '\n',
        '\u000b', // vertical tab
        '\u000c', // form feed
        '0'
    };
    static string TrimEndWhitespaceAndZeros(string s) {
        return s.Contains('.') ? s.TrimEnd(whitespaceAndZero) : s;
    }
    static bool TryParseAfterTrim(string s, out decimal d) {
        return Decimal.TryParse(TrimEndWhiteSpaceAndZeros(s), out d);
    }
