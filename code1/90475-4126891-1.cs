    public static void Combine(string[] inputFiles, Stream output)
    {
        foreach (string file in inputFiles)
        {
            Mp3FileReader reader = new Mp3FileReader(file);
            if ((output.Position == 0) && (reader.Id3v2Tag != null))
            {
                output.Write(reader.Id3v2Tag.RawData,
                             0,
                             reader.Id3v2Tag.RawData.Length);
            }
            Mp3Frame frame;
            while ((frame = reader.ReadNextFrame()) != null)
            {
                output.Write(frame.RawData, 0, frame.RawData.Length);
            }
        }
    }
