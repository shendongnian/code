    [ScriptableMember]
    public void SeekPlayback(string time)
    {
        TimeSpan tsTime = TimeSpan.Parse(time);
        mediaControls.Seek(tsTime);
    }
