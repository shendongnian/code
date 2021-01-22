    public void writeFile(byte[] buffer, int start, int size)
        {
            lock (mFileStream)
            {
            mFileStream.Seek(start, SeekOrigin.Begin);
            mFileStream.Write(buffer, 0, size);
            return;
            }
        }
