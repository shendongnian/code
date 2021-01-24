    while (condition == true)
    {
        //First part
        using (var stream = File.Create(audioPath))
        {
            using (WaveFileWriter writer = new WaveFileWriter(stream, waveFormat))
            {
                writer.Write(audioBytes.ToArray(), 0, audioBytes.ToArray().Length);
            }
        }
        //Second part
        using (Process.Start("cmd.exe", commands)) { };
        Thread.Sleep(1000);
    }
