    public static string DecodeQuotedPrintables(string input, Encoding encoding)
        {
            var regex = new Regex(@"\=(?<Symbol>[0-9A-Z]{2})", RegexOptions.Multiline);
            var matches = regex.Matches(input);
            var bytes = new byte[matches.Count];
            for (var i = 0; i < matches.Count; i++)
            {
                bytes[i] = Convert.ToByte(matches[i].Groups["Symbol"].Value, 16);
            }
            return encoding.GetString(bytes);
        }
