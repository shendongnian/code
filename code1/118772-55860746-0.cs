    private uint Crc32CAlgorithmBigCrc(string fileName)
    {
        uint hash = 0;
        byte[] buffer = null;
        FileInfo fileInfo = new FileInfo(fileName);
        long fileLength = fileInfo.Length;
        int blockSize = 1024000000;
        decimal div = fileLength / blockSize;
        int blocks = (int)Math.Floor(div);
        int restBytes = (int)(fileLength - (blocks * blockSize));
        long offsetFile = 0;
        uint interHash = 0;
        Crc32CAlgorithm Crc32CAlgorithm = new Crc32CAlgorithm();
        bool firstBlock = true;
        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            buffer = new byte[blockSize];
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (blocks > 0)
                {
                    blocks -= 1;
                    fs.Seek(offsetFile, SeekOrigin.Begin);
                    buffer = br.ReadBytes(blockSize);
                    if (firstBlock)
                    {
                        firstBlock = false;
                        interHash = Crc32CAlgorithm.Compute(buffer);
                        hash = interHash;
                    }
                    else
                    {
                        hash = Crc32CAlgorithm.Append(interHash, buffer);
                    }
                    offsetFile += blockSize;
                }
                if (restBytes > 0)
                {
                    Array.Resize(ref buffer, restBytes);
                    fs.Seek(offsetFile, SeekOrigin.Begin);
                    buffer = br.ReadBytes(restBytes);
                    hash = Crc32CAlgorithm.Append(interHash, buffer);
                }
                buffer = null;
            }
        }
        //MessageBox.Show(hash.ToString());
        //MessageBox.Show(hash.ToString("X"));
        return hash;
    }
