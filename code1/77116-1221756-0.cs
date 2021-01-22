        public static void ReverseWaveFile(string inputFile, string outputFile)
        {
            using (WaveFileReader reader = new WaveFileReader(inputFile))
            {
                int blockAlign = reader.WaveFormat.BlockAlign;
                using (WaveFileWriter writer = new WaveFileWriter(outputFile, reader.WaveFormat))
                {
                    byte[] buffer = new byte[blockAlign];
                    long samples = reader.Length / blockAlign;
                    for (long sample = samples - 1; sample >= 0; sample--)
                    {
                        reader.Position = sample * blockAlign;
                        reader.Read(buffer, 0, blockAlign);
                        writer.WriteData(buffer, 0, blockAlign);
                    }
                }
            }
        }
