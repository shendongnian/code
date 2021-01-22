    class StandardInput : IDisposable
    {
        private readonly TextReader reader;
        public StandardInput(TextReader reader)
        {
            this.reader = reader;
        }
        public int ReadInt32()
        {
            while (!char.IsDigit((char)reader.Peek()) && reader.Peek() != -1)
            {
                reader.Read();
            }
            var builder = new StringBuilder();
            while (char.IsDigit((char) reader.Peek()))
                builder.Append((char) reader.Read());
            return builder.Length == 0 ? -1 : int.Parse(builder.ToString());
        }
        public double ReadDouble()
        {
            while (!char.IsDigit((char)reader.Peek()) && reader.Peek() != '.'
                                                      && reader.Peek() != -1)
            {
                reader.Read();
            }
            var builder = new StringBuilder();
            if (reader.Peek() == '.')
                builder.Append((char) reader.Read());
            while (char.IsDigit((char)reader.Peek()))
                builder.Append((char)reader.Read());
            if (reader.Peek() == '.' && !builder.ToString().Contains("."))
            {
                builder.Append((char)reader.Read());
                while (char.IsDigit((char)reader.Peek()))
                    builder.Append((char)reader.Read());
            }
            return builder.Length == 0 ? -1 : double.Parse(builder.ToString());
        }
        public void Dispose()
        {
            reader.Dispose();
        }
    }
