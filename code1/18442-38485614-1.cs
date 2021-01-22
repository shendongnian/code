    using Luminescence.Xiph;
    OggTagger ogg = new OggTagger(@"C:\Song.ogg");
    
    // Load duration
    DateTime time = new DateTime(0);
    time = time.AddSeconds(ogg.Duration);
    
    // Tags manipulation
    string artist = ogg.Artist;
    ogg.Title = "Creep";
    SortedList<string, List<string>> tags = ogg.GetAllTags();
    BitmapFrame cover = ogg.FlacArts[0].Picture;
