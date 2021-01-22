    var dictionary = new Dictionary<string, ISoundSource>();
    foreach (XmlElement Path in locaties)
    {
        ISoundSource track = engine.AddSoundSourceFromFile(Path.InnerXml);
        mixarray.Add(track);
        dictionary[track.Name] = track;
    }
    
    ISoundSource item = dictionary["MyTrackName"];
