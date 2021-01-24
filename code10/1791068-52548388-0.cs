    OddFileReader.NextData nextData;
    while ((nextData = reader.ReportNextData()) != OddFileReader.NextData.Eof)
    {
        // Call appropriate Read*() here.
    }
    public class OddFileReader : IDisposable
    {
        public enum NextData
        {
            Unknown,
            Eof,
            String,
            BinaryLength,
            BinaryData
        }
        private Stream source;
        private byte[] byteBuffer;
        private int bufferOffset;
        private int bufferEnd;
        private NextData nextData;
        private int binaryOffset;
        private int binaryEnd;
        private char[] characterBuffer;
        public OddFileReader(Stream source)
        {
            this.source = source;
        }
        public NextData ReportNextData()
        {
            if (nextData != NextData.Unknown)
            {
                return nextData;
            }
            if (!PopulateBufferIfNeeded(1))
            {
                return (nextData = NextData.Eof);
            }
            if (byteBuffer[bufferOffset] == '$')
            {
                return (nextData = NextData.BinaryLength);
            }
            else
            {
                return (nextData = NextData.String);
            }
        }
        public string ReadString()
        {
            ReportNextData();
            if (nextData == NextData.Eof)
            {
                throw new EndOfStreamException();
            }
            else if (nextData != NextData.String)
            {
                throw new InvalidOperationException("Attempt to read non-string data as string");
            }
            if (characterBuffer == null)
            {
                characterBuffer = new char[1];
            }
            StringBuilder stringBuilder = new StringBuilder();
            Decoder decoder = Encoding.Unicode.GetDecoder();
            while (nextData == NextData.String)
            {
                byte b = byteBuffer[bufferOffset];
                if (b == '$')
                {
                    nextData = NextData.BinaryLength;
                    break;
                }
                else if (b == ':')
                {
                    nextData = NextData.Unknown;
                    bufferOffset++;
                    break;
                }
                else
                {
                    if (decoder.GetChars(byteBuffer, bufferOffset++, 1, characterBuffer, 0) == 1)
                    {
                        stringBuilder.Append(characterBuffer[0]);
                    }
                    if (bufferOffset == bufferEnd && !PopulateBufferIfNeeded(1))
                    {
                        nextData = NextData.Eof;
                        break;
                    }
                }
            }
            return stringBuilder.ToString();
        }
        public int ReadBinaryLength()
        {
            ReportNextData();
            if (nextData == NextData.Eof)
            {
                throw new EndOfStreamException();
            }
            else if (nextData != NextData.BinaryLength)
            {
                throw new InvalidOperationException("Attempt to read non-binary-length data as binary length");
            }
            bufferOffset++;
            if (!PopulateBufferIfNeeded(sizeof(Int32)))
            {
                nextData = NextData.Eof;
                throw new EndOfStreamException();
            }
            binaryEnd = BitConverter.ToInt32(byteBuffer, bufferOffset);
            binaryOffset = 0;
            bufferOffset += sizeof(Int32);
            nextData = NextData.BinaryData;
            return binaryEnd;
        }
        public int ReadBinaryData(byte[] buffer, int offset, int count)
        {
            ReportNextData();
            if (nextData == NextData.Eof)
            {
                throw new EndOfStreamException();
            }
            else if (nextData != NextData.BinaryData)
            {
                throw new InvalidOperationException("Attempt to read non-binary data as binary data");
            }
            if (count > binaryEnd - binaryOffset)
            {
                throw new EndOfStreamException();
            }
            int bytesRead;
            if (bufferOffset < bufferEnd)
            {
                bytesRead = Math.Min(count, bufferEnd - bufferOffset);
                Array.Copy(byteBuffer, bufferOffset, buffer, offset, bytesRead);
                bufferOffset += bytesRead;
            }
            else if (count < byteBuffer.Length)
            {
                if (!PopulateBufferIfNeeded(1))
                {
                    throw new EndOfStreamException();
                }
                bytesRead = Math.Min(count, bufferEnd - bufferOffset);
                Array.Copy(byteBuffer, bufferOffset, buffer, offset, bytesRead);
                bufferOffset += bytesRead;
            }
            else
            {
                bytesRead = source.Read(buffer, offset, count);
            }
            binaryOffset += bytesRead;
            if (binaryOffset == binaryEnd)
            {
                nextData = NextData.Unknown;
            }
            return bytesRead;
        }
        private bool PopulateBufferIfNeeded(int minimumBytes)
        {
            if (byteBuffer == null)
            {
                byteBuffer = new byte[8192];
            }
            if (bufferEnd - bufferOffset < minimumBytes)
            {
                int shiftCount = bufferEnd - bufferOffset;
                if (shiftCount > 0)
                {
                    Array.Copy(byteBuffer, bufferOffset, byteBuffer, 0, shiftCount);
                }
                bufferOffset = 0;
                bufferEnd = shiftCount;
                while (bufferEnd - bufferOffset < minimumBytes)
                {
                    int bytesRead = source.Read(byteBuffer, bufferEnd, byteBuffer.Length - bufferEnd);
                    if (bytesRead == 0)
                    {
                        return false;
                    }
                    bufferEnd += bytesRead;
                }
            }
            return true;
        }
        public void Dispose()
        {
            Stream source = this.source;
            this.source = null;
            if (source != null)
            {
                source.Dispose();
            }
        }
    }
