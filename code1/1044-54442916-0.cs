    using Melanchall.DryWetMidi.Devices;
    using Melanchall.DryWetMidi.Smf;
    
    // ...
    
    var midiFile = MidiFile.Read("Greatest song ever.mid");
    
    using (var outputDevice = OutputDevice.GetByName("Microsoft GS Wavetable Synth"))
    {
        midiFile.Play(outputDevice);
    }
