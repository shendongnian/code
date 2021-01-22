    public static class UnicodeStringExtensions
    {
        public static string EncodeNonAsciiCharacters(this string value) {
            var bytes = Encoding.Unicode.GetBytes(value);
            var sb = StringBuilderCache.Acquire(value.Length);
            bool encodedsomething = false;
            for (int i = 0; i < bytes.Length; i += 2) {
                var c = BitConverter.ToUInt16(bytes, i);
                if ((c >= 0x20 && c <= 0x7f) || c == 0x0A || c == 0x0D) {
                    sb.Append((char) c);
                } else {
                    sb.Append($"\\u{c:x4}");
                    encodedsomething = true;
                }
            }
            if (!encodedsomething) {
                StringBuilderCache.Release(sb);
                return value;
            }
            return StringBuilderCache.GetStringAndRelease(sb);
        }
        public static string DecodeEncodedNonAsciiCharacters(this string value)
          => Regex.Replace(value,/*language=regexp*/@"(?:\\u[a-fA-F0-9]{4})+", Decode);
        static readonly string[] Splitsequence = new [] { "\\u" };
        private static string Decode(Match m) {
            var bytes = m.Value.Split(Splitsequence, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => ushort.Parse(s, NumberStyles.HexNumber)).SelectMany(BitConverter.GetBytes).ToArray();
            return Encoding.Unicode.GetString(bytes);
        }
    }
