        public static byte[] ReadAllBytesUnbuffered(string filePath)
        {
            const FileOptions FileFlagNoBuffering = (FileOptions)0x20000000;
            var fileInfo = new FileInfo(filePath);
            long fileLength = fileInfo.Length;
            int bufferSize = (int)Math.Min(fileLength, int.MaxValue / 2);
            bufferSize += ((bufferSize + 1023) & ~1023) - bufferSize;
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None,
                                               bufferSize, FileFlagNoBuffering | FileOptions.SequentialScan))
            {
                long length = stream.Length;
                if (length > 0x7fffffffL)
                {
                    throw new IOException("File too long over 2GB");
                }
                int offset = 0;
                int count = (int)length;
                var buffer = new byte[count];
                while (count > 0)
                {
                    int bytesRead = stream.Read(buffer, offset, count);
                    if (bytesRead == 0)
                    {
                        throw new EndOfStreamException("Read beyond end of file EOF");
                    }
                    offset += bytesRead;
                    count -= bytesRead;
                }
                return buffer;
            }
        }
