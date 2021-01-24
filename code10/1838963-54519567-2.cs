    int item = 1;
    var inputWaveFiles = new List<WaveFile>();
    while (File.Exists($@"D:\test\pp{item}.wav"))
    {
        var waveFile = WaveFile.ReadWaveFile($@"D:\test\pp{item}.wav");
        inputWaveFiles.Add(waveFile);
        item++;
    }
    WaveFile.Merge(inputWaveFiles, @"D:\test\output.wav");
    public class WaveFile
    {
        public string Path { get; set; }
        public int Length { get; set; }
        public short Channels { get; set; }
        public int SampleRate { get; set; }
        public int DataLength { get; set; }
        public short BitsPerSample { get; set; }
        private void WriteHeader(string filename)
        {
            using (var file = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new BinaryWriter(file))
                {
                    file.Position = 0;
                    writer.Write(new char[4] { 'R', 'I', 'F', 'F' });
                    writer.Write(Length);
                    writer.Write(new char[8] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
                    writer.Write((int)16);
                    writer.Write((short)1);
                    writer.Write(Channels);
                    writer.Write(SampleRate);
                    writer.Write((int)(SampleRate * ((BitsPerSample * Channels) / 8)));
                    writer.Write((short)((BitsPerSample * Channels) / 8));
                    writer.Write(BitsPerSample);
                    writer.Write(new char[4] { 'd', 'a', 't', 'a' });
                    writer.Write(DataLength);
                }
            }
        }
        public static WaveFile ReadWaveFile(string filename)
        {
            var waveFile = new WaveFile();
            waveFile.Path = filename;
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(file))
                {
                    waveFile.Length = (int)file.Length - 8;
                    file.Position = 22;
                    waveFile.Channels = reader.ReadInt16();
                    file.Position = 24;
                    waveFile.SampleRate = reader.ReadInt32();
                    file.Position = 34;
                    waveFile.BitsPerSample = reader.ReadInt16();
                    waveFile.DataLength = (int)file.Length - 44;
                }
            }
            return waveFile;
        }
        public static void Merge(List<WaveFile> waveFiles, string outputFilename)
        {
            var outputWave = new WaveFile();
            
            foreach(var waveFile in waveFiles)
            {
                outputWave.DataLength += waveFile.DataLength;
                outputWave.Length += waveFile.Length;
            }
            // Generate file with header (I just copy the sample rate etc.. from the first sound file)
            outputWave.BitsPerSample = waveFiles[0].BitsPerSample;
            outputWave.Channels = waveFiles[0].Channels;
            outputWave.SampleRate = waveFiles[0].SampleRate;
            outputWave.WriteHeader(outputFilename);
            // Append data
            foreach (var waveFile in waveFiles)
            {
                // Read wave file
                using (var fileReader = new FileStream(waveFile.Path, FileMode.Open, FileAccess.Read))
                {
                    var inputData = new byte[fileReader.Length - 44];
                    fileReader.Position = 44;
                    fileReader.Read(inputData, 0, inputData.Length);
                    // Write wave file
                    using (var fileWriter = new FileStream(outputFilename, FileMode.Append, FileAccess.Write))
                    {
                        using (var writer = new BinaryWriter(fileWriter))
                        {
                            writer.Write(inputData);
                        }
                    }
                }
            }
        }
    }
