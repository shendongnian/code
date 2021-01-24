    using MusicTheory = Melanchall.DryWetMidi.MusicTheory;
    
    // ...
    
    var pattern = new PatternBuilder()
        .Note(MusicTheory.Octave.Get(3).ASharp, length: MusicalTimeSpan.Quarter)
        .Note(MusicTheory.Octave.Get(3).C, length: MusicalTimeSpan.Eighth)
        // ...
        .Build();
    
    using (var outputDevice = OutputDevice.GetByName("Microsoft GS Wavetable Synth"))
    {
        pattern.Play(TempoMap.Default, (FourBitNumber)10, outputDevice);
    }
