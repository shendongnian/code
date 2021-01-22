    public static class FileUtility
    {
        private const char PrefixChar = '%';
        private static readonly int MaxLength;
        private static readonly Dictionary<char,char[]> Illegals;
        static FileUtility()
        {
            List<char> illegal = new List<char> { PrefixChar };
            illegal.AddRange(Path.GetInvalidFileNameChars());
            MaxLength = illegal.Select(x => ((int)x).ToString().Length).Max();
            Illegals = illegal.ToDictionary(x => x, x => ((int)x).ToString("D" + MaxLength).ToCharArray());
        }
     
        public static string FilenameEncode(string s)
        {
            var builder = new StringBuilder();
            char[] replacement;
            using (var reader = new StringReader(s))
            {
                while (true)
                {
                    int read = reader.Read();
                    if (read == -1)
                        break;
                    char c = (char)read;
                    if(Illegals.TryGetValue(c,out replacement))
                    {
                        builder.Append(PrefixChar);
                        builder.Append(replacement);
                    }
                    else
                    {
                        builder.Append(c);
                    }
                }
            }
            return builder.ToString();
        }
     
        public static string FilenameDecode(string s)
        {
            var builder = new StringBuilder();
            char[] buffer = new char[MaxLength];
            using (var reader = new StringReader(s))
            {
                while (true)
                {
                    int read = reader.Read();
                    if (read == -1)
                        break;
                    char c = (char)read;
                    if (c == PrefixChar)
                    {
                        reader.Read(buffer, 0, MaxLength);
                        var encoded =(char) ParseCharArray(buffer);
                        builder.Append(encoded);
                    }
                    else
                    {
                        builder.Append(c);
                    }
                }
            }
            return builder.ToString();
        }
     
        public static int ParseCharArray(char[] buffer)
        {
            int result = 0;
            foreach (char t in buffer)
            {
                int digit = t - '0';
                if ((digit < 0) || (digit > 9))
                {
                    throw new ArgumentException("Input string was not in the correct format");
                }
                result *= 10;
                result += digit;
            }
            return result;
        }
    }
