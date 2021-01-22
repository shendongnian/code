    private static void SkipSilent(string fileName, short silentLevel)
    {
        WaveReader wr = new WaveReader(File.OpenRead(fileName));
        IntPtr format = wr.ReadFormat();
        WaveWriter ww = new WaveWriter(File.Create(fileName + ".wav"), 
            AudioCompressionManager.FormatBytes(format));
        int i = 0;
        while (true)
        {
            byte[] data = wr.ReadData(i, 1);
            if (data.Length == 0)
            {
                break;
            }
            if (!AudioCompressionManager.CheckSilent(format, data, silentLevel))
            {
                ww.WriteData(data);
            }
        }
        ww.Close();
        wr.Close();
    }
