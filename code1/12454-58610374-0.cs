    public enum ChannelMessageTypes : byte
    {
        Min                 = 0x80, // Or could be: Min = NoteOff
        NoteOff             = 0x80,
        NoteOn              = 0x90,
        PolyKeyPressure     = 0xA0,
        ControlChange       = 0xB0,
        ProgramChange       = 0xC0,
        ChannelAfterTouch   = 0xD0,
        PitchBend           = 0xE0,
        Max                 = 0xE0  // Or could be: Max = PitchBend
    }
    // I use it like this to check if a ... is a channel message.
    if(... >= ChannelMessageTypes.Min || ... <= ChannelMessages.Max)
    {
        Console.WriteLine("Channel message received!");
    }
