    public static string DecodeQuotedPrintable(string input, string charSet)
        {
            
            Encoding enc;
            try
            {
                enc = Encoding.GetEncoding(charSet);
            }
            catch
            {
                enc = new UTF8Encoding();
            }
            input = input.Replace("=\r\n=", "=");
            input = input.Replace("=\r\n ", "\r\n ");
            input = input.Replace("= \r\n", " \r\n");
            var occurences = new Regex(@"(=[0-9A-Z]{2})", RegexOptions.Multiline); //{1,}
            var matches = occurences.Matches(input);
            foreach (Match match in matches)
            {
                try
                {
                    byte[] b = new byte[match.Groups[0].Value.Length / 3];
                    for (int i = 0; i < match.Groups[0].Value.Length / 3; i++)
                    {
                        b[i] = byte.Parse(match.Groups[0].Value.Substring(i * 3 + 1, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    }
                    char[] hexChar = enc.GetChars(b);
                    input = input.Replace(match.Groups[0].Value, new String(hexChar));
                    
                }
                catch
                { Console.WriteLine("QP dec err"); }
            }
            input = input.Replace("?=", ""); //.Replace("\r\n", "");
            return input;
        }
