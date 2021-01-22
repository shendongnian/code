        /// <summary>
        /// Replaces invalid Xml characters from input file, NOTE: if replacement character is \0, then invalid Xml character is removed, instead of 1-for-1 replacement
        /// </summary>
        public class InvalidXmlCharacterReplacingStreamReader : StreamReader
        {
            private readonly char _replacementCharacter;
            public InvalidXmlCharacterReplacingStreamReader(string fileName, char replacementCharacter)
                : base(fileName)
            {
                _replacementCharacter = replacementCharacter;
            }
            public override int Peek()
            {
                int ch = base.Peek();
                if (ch != -1 && IsInvalidChar(ch))
                {
                    if ('\0' == _replacementCharacter)
                        return Peek(); // peek at the next one
                    return _replacementCharacter;
                }
                return ch;
            }
            public override int Read()
            {
                int ch = base.Read();
                if (ch != -1 && IsInvalidChar(ch))
                {
                    if ('\0' == _replacementCharacter)
                        return Read(); // read next one
                    return _replacementCharacter;
                }
                return ch;
            }
            public override int Read(char[] buffer, int index, int count)
            {
                int readCount= 0, ch;
                for (int i = 0; i < count && (ch = Read()) != -1; i++)
                {
                    readCount++;
                    buffer[index + i] = (char)ch;
                }
                return readCount;
            }
            
            private static bool IsInvalidChar(int ch)
            {
                return !XmlConvert.IsXmlChar((char)ch);
            }
        }
