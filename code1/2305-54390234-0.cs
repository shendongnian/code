    public class InvalidXmlCharacterReplacingStreamReader : StreamReader
    {
        private readonly char _replacementCharacter;
        public InvalidXmlCharacterReplacingStreamReader(string fileName, char replacementCharacter) : base(fileName)
        {
            _replacementCharacter = replacementCharacter;
        }
        public InvalidXmlCharacterReplacingStreamReader(Stream stream, char replacementCharacter) : base(stream)
        {
            _replacementCharacter = replacementCharacter;
        }
        public override int Peek()
        {
            var ch = base.Peek();
            if (ch != -1 && IsInvalidChar(ch))
            {
                return _replacementCharacter;
            }
            return ch;
        }
        public override int Read()
        {
            var ch = base.Read();
            if (ch != -1 && IsInvalidChar(ch))
            {
                return _replacementCharacter;
            }
            return ch;
        }
        public override int Read(char[] buffer, int index, int count)
        {
            var readCount = base.Read(buffer, index, count);
            ReplaceInBuffer(buffer, index, readCount);
            return readCount;
        }
        public override async Task<int> ReadAsync(char[] buffer, int index, int count)
        {
            var readCount = await base.ReadAsync(buffer, index, count).ConfigureAwait(false);
            ReplaceInBuffer(buffer, index, readCount);
            return readCount;
        }
        private void ReplaceInBuffer(char[] buffer, int index, int readCount)
        {
            for (var i = index; i < readCount + index; i++)
            {
                var ch = buffer[i];
                if (IsInvalidChar(ch))
                {
                    buffer[i] = _replacementCharacter;
                }
            }
        }
        private static bool IsInvalidChar(int ch)
        {
            return IsInvalidChar((char)ch);
        }
        private static bool IsInvalidChar(char ch)
        {
            return !XmlConvert.IsXmlChar(ch);
        }
    }
