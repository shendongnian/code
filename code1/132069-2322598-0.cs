    static class TextReaderEx {
        static public string ReadWord(this TextReader reader) {
            int c;
            // Skip leading whitespace
            while (-1 != (c = reader.Peek()) && char.IsWhiteSpace((char)c)) reader.Read();
            // Read to next whitespace
            var result = new StringBuilder();
            while (-1 != (c = reader.Peek()) && !char.IsWhiteSpace((char)c)) {
                reader.Read();
                result.Append((char)c);
            }
            return result.ToString();
        }
    }
    ...
        int.Parse(Console.In.ReadWord())
