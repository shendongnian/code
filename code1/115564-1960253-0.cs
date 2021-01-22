    [DllImport("WinMM.dll")]    
    public static extern bool  PlaySound(string name, int hModule, int flags);
    // see mmsystem.h for these flags
    public int SND_SYNC      = 0x00000000; // don't return until playback is done
    public int SND_ASYNC     = 0x00000001; // play asynchronously    
    public int SND_NODEFAULT = 0x00000002; // don't play the default sound if n
    public int SND_MEMORY    = 0x00000004; // name is actual a pointer to a WAVEHEADER
    public int SND_LOOP      = 0x00000008; // loop the sound until next call to PlaySound (use with SND_ASYNC)
    public int SND_NOSTOP    = 0x00000010; // don't stop any currently playing sound
    public int SND_FILENAME  = 0x00020000; // name is a filename (it's a sound name otherwise)
    public int SND_NOSTOP    = 0x00000010; // don't stop any currently playing sound
