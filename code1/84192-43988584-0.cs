    using System;
    using System.IO;
    using System.Text;
    namespace FilePrepender
    {
        public class FilePrepender
        {
            private string file=null;
            public FilePrepender(string filePath)
            {
                file = filePath;
            }
            public void prependline(string line)
            {
                prepend(line + Environment.NewLine);
            }
            private void shiftSection(byte[] chunk,FileStream readStream,FileStream writeStream)
            {
                long initialOffsetRead = readStream.Position;
                long initialOffsetWrite= writeStream.Position;
                int offset = 0;
                int remaining = chunk.Length;
                do//ensure that the entire chunk length gets read and shifted
                {
                    int read = readStream.Read(chunk, offset, remaining);
                    offset += read;
                    remaining -= read;
                } while (remaining > 0);
                writeStream.Write(chunk, 0, chunk.Length);
                writeStream.Seek(initialOffsetWrite, SeekOrigin.Begin);
                readStream.Seek(initialOffsetRead, SeekOrigin.Begin);
            }
            public void prepend(string text)
            {
                byte[] bytes = Encoding.Default.GetBytes(text);
                byte[] chunk = new byte[bytes.Length];
                using (FileStream readStream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using(FileStream writeStream = File.Open(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        readStream.Seek(0, SeekOrigin.End);//seek chunk.Length past the end of the file 
                        writeStream.Seek(chunk.Length, SeekOrigin.End);//which lets the loop run without special cases
                        long size = readStream.Position;
                        //while there's a whole chunks worth above the read head, shift the file contents down from the end
                        while(readStream.Position - chunk.Length >= 0)
                        {
                            readStream.Seek(-chunk.Length, SeekOrigin.Current);
                            writeStream.Seek(-chunk.Length, SeekOrigin.Current);
                            shiftSection(chunk, readStream, writeStream);
                        }
                        //clean up the remaining shift for the bytes that don't fit in size%chunk.Length
                        readStream.Seek(0, SeekOrigin.Begin);
                        writeStream.Seek(Math.Min(size, chunk.Length), SeekOrigin.Begin);
                        shiftSection(chunk, readStream, writeStream);
                        //finally, write the text you want to prepend
                        writeStream.Seek(0,SeekOrigin.Begin);
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }
