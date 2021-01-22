    static void Mp4ToOgg(string fileName)
    {
        DsReader dr = new DsReader(fileName);
        if (dr.HasAudio)
        {
            string waveFile = fileName + ".wav";
            WaveWriter ww = new WaveWriter(File.Create(waveFile),
                AudioCompressionManager.FormatBytes(dr.ReadFormat()));
            ww.WriteData(dr.ReadData());
            ww.Close();
            dr.Close();
            try
            {
                Sox.Convert(@"sox.exe", waveFile, waveFile + ".ogg", SoxAudioFileType.Ogg);
            }
            catch (SoxException ex)
            {
                throw;
            }
        }
    }
