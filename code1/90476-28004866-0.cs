    public static void Combine(string[] mp3Files, string mp3OuputFile)
    {
        using (var w = new  BinaryWriter(File.Create(mp3OuputFile)))
        {
            new List<string>(mp3Files).ForEach(f => w.Write(File.ReadAllBytes(f)));
        }
    }
