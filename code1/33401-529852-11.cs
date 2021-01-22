    public static class ShortCodes
    {
        // You may change the "shortcode_Keyspace" variable to contain as many or as few characters as you
        // please.  The more characters that are included in the "shortcode_Keyspace" constant, the shorter
        // the codes you can produce for a given long.
        private static string shortcodeKeyspace = "abcdefghijklmnopqrstuvwxyz0123456789";
        public static string LongToShortCode(long number)
        {
            // Guard clause.  If passed 0 as input
            // we always return empty string.
            if (number == 0)
            {
                return string.Empty;
            }
            var keyspaceLength = shortcodeKeyspace.Length;
            var shortcodeResult = "";
            var numberToEncode = number;
            var i = 0;
            do
            {
                i++;
                var characterValue = numberToEncode % keyspaceLength == 0 ? keyspaceLength : numberToEncode % keyspaceLength;
                var indexer = (int) characterValue - 1;
                shortcodeResult = shortcodeKeyspace[indexer] + shortcodeResult;
                numberToEncode = ((numberToEncode - characterValue) / keyspaceLength);
            }
            while (numberToEncode != 0);
            return shortcodeResult;
        }
        public static long ShortCodeToLong(string shortcode)
        {
            var keyspaceLength = shortcodeKeyspace.Length;
            long shortcodeResult = 0;
            var shortcodeLength = shortcode.Length;
            var codeToDecode = shortcode;
            foreach (var character in codeToDecode)
            {
                shortcodeLength--;
                var codeChar = character;
                var codeCharIndex = shortcodeKeyspace.IndexOf(codeChar);
                if (codeCharIndex < 0)
                {
                    // The character is not part of the keyspace and so entire shortcode is invalid.
                    return 0;
                }
                try
                {
                    checked
                    {
                        shortcodeResult += (codeCharIndex + 1) * (long) (Math.Pow(keyspaceLength, shortcodeLength));
                    }
                }
                catch(OverflowException)
                {
                    // We've overflowed the maximum size for a long (possibly the shortcode is invalid or too long).
                    return 0;
                }
            }
            return shortcodeResult;
        }
    }
