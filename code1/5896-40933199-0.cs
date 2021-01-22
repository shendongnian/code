    using TagLib.Mpeg;
    public static double GetSoundLength(string FilePath)
    {
        AudioFile ObjAF = new AudioFile(FilePath);
        return ObjAF.Properties.Duration.TotalSeconds;
    }
