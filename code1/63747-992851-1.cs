    public static void DoSomething_HelpMe()
    {
        MusicTrack track1 = new MusicTrack();
        MusicTrack track2 = new MusicTrack();
        // Set some values on the tracks
        foreach (ITag tag in track1.Tags.Values)
            tag.CopyFrom(false, track2.Tags[tag.TagName], true);
    }
