    public static IEnumerable<int> LoadFileWithProgress(string filename, StringBuilder stringData)
    {
        const int charBufferSize = 4096;
        using (FileStream fs = File.OpenRead(filename))
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                long length = fs.Length;
                int numberOfChunks = Convert.ToInt32((length / charBufferSize)) + 1;
                double iter = 100 / Convert.ToDouble(numberOfChunks);
                double currentIter = 0;
                yield return Convert.ToInt32(currentIter);
                while (true)
                {
                    char[] buffer = br.ReadChars(charBufferSize);
                    if (buffer.Length == 0) break;
                    stringData.Append(buffer);
                    currentIter += iter;
                    yield return Convert.ToInt32(currentIter);
                }
            }
        }
    }
