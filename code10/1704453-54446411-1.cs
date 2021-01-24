    using Melanchall.DryWetMidi.Devices;
    using Melanchall.DryWetMidi.Core;
    
    // ...
    
    using (var outputDevice = OutputDevice.GetByName("Output device")) // or GetById(1)
    {
        outputDevice.SendEvent(new NoteOnEvent());
    }
