    static void Main(string[] args)
    {
        string fileName = @"C:\Temp\Test.m3u";
        using (StreamWriter writer = new StreamWriter(fileName, false,
            Encoding.GetEncoding(1252)))
        {
            writer.WriteLine("#EXTM3U");
            writer.WriteLine("#EXTINF:140,Yann Tiersen " +
                "- Comptine D'Un Autre Été: L'Après Midi");
            writer.WriteLine("04-Comptine D'Un Autre Été- L'Après Midi.mp3");
        }
    }
