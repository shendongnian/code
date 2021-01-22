    public static IEnumerable<int> LoadFileWithProgress(string filename, StringBuilder stringData)
    {
        const int charBufferSize = 4096;
        using (FileStream fs = File.OpenRead(filename))
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                long length = fs.Length;
                int numberOfChunks = Convert.ToInt32((length / charBufferSize)) + 1;
                int iter = Convert.ToInt32(100 / numberOfChunks);
                int currentIter = 0;
                yield return currentIter;
                while (true)
                {
                    char[] buffer = br.ReadChars(charBufferSize);
                    if (buffer.Length == 0) break;
                    stringData.Append(buffer);
                    currentIter += iter;
                    yield return currentIter;
                }
            }
        }
    }
