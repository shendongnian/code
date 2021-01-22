    void AnyToWav(string fileName)
    {
        DsReader dr1 = new DsReader(fileName);
        if (dr1.HasAudio)
        {
            WaveWriter ww = new WaveWriter(File.Create(fileName + ".wav"), 
               AudioCompressionManager.FormatBytes(dr1.ReadFormat()));
            ww.WriteData(dr1.ReadData());
            ww.Close();
            Console.WriteLine("Done!");
        }
        else
        {
            Console.WriteLine("Has no audio");
        }
    }
