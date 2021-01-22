        private static Regex DECODING_REGEX = new Regex(@"\\u(?<Value>[a-fA-F0-9]{4})", RegexOptions.Compiled);
        private const string PLACEHOLDER = @"#!#";
        public static string DecodeEncodedNonAsciiCharacters(this string value)
        {
            return DECODING_REGEX.Replace(
                value.Replace(@"\\", PLACEHOLDER),
                m => { 
                    return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString(); })
                .Replace(PLACEHOLDER, @"\\");
        }
