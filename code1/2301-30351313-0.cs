    public class InvalidXmlCharacterReplacingStreamReader : StreamReader
    {
        private readonly char _replacementCharacter;
        public InvalidXmlCharacterReplacingStreamReader(string fileName, char replacementCharacter) : base(fileName)
        {
            this._replacementCharacter = replacementCharacter;
        }
        public override int Peek()
        {
            int ch = base.Peek();
            if (ch != -1 && IsInvalidChar(ch))
            {
                return this._replacementCharacter;
            }
            return ch;
        }
        public override int Read()
        {
            int ch = base.Read();
            if (ch != -1 && IsInvalidChar(ch))
            {
                return this._replacementCharacter;
            }
            return ch;
        }
        public override int Read(char[] buffer, int index, int count)
        {
            int readCount = base.Read(buffer, index, count);
            for (int i = index; i < readCount + index; i++)
            {
                char ch = buffer[i];
                if (IsInvalidChar(ch))
                {
                    buffer[i] = this._replacementCharacter;
                }
            }
            return readCount;
        }
        private static bool IsInvalidChar(int ch)
        {
            return (ch < 0x0020 || ch > 0xD7FF) &&
                   (ch < 0xE000 || ch > 0xFFFD) &&
                    ch != 0x0009 &&
                    ch != 0x000A &&
                    ch != 0x000D;
        }
    }
