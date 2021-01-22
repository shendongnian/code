    public static class TextReaderTokenizer
    {
        // Adjust as needed. -1 is EOF.
        private static int[] whitespace = { -1, ' ', '\r' , '\n', '\t' };
        public static T ReadToken<T>(this TextReader reader)
        {
            StringBuilder sb = new StringBuilder();
            while (Array.IndexOf(whitespace, reader.Peek()) < 0)
            {
                sb.Append((char)reader.Read());
            }
            return (T)Convert.ChangeType(sb.ToString(), typeof(T));
        }    
    }
