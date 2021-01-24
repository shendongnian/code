    using Melanchall.DryWetMidi.Common;
    using Melanchall.DryWetMidi.Devices;
    using Melanchall.DryWetMidi.Smf;
    using Melanchall.DryWetMidi.Smf.Interaction;
    
    // ...
    
    var eventsToPlay = new MidiEvent[]
    {
        new NoteOnEvent((SevenBitNumber)100, SevenBitNumber.MaxValue) { Channel = (FourBitNumber)10 },
        new NoteOffEvent((SevenBitNumber)100, SevenBitNumber.MinValue) { Channel = (FourBitNumber)10 },
        // ...
    };
    
    using (var outputDevice = OutputDevice.GetByName("Microsoft GS Wavetable Synth"))
    using (var playback = new Playback(eventsToPlay, TempoMap.Default, outputDevice))
    {
        playback.Play();
    }
