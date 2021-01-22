    public static class UnicodeStringExtensions {
      public static string EncodeNonAsciiCharacters(this string value)
        => Regex.Replace(value, @"[^\u0020-\u007F]", Encode);
      private static string Encode(Match m)
        => $"\\u{(int) m.Value[0]:x4}";
      public static string DecodeEncodedNonAsciiCharacters(this string value)
        => Regex.Replace(value, @"\\u(?<Value>[a-fA-F0-9]{4})", Decode);
      private static string Decode(Match m)
        => ((char) int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
    }
