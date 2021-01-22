	//  flag values for SoundFlags argument on PlaySound
	public static int SND_SYNC        = 0x0000;      // play synchronously (default)
	public static int SND_ASYNC       = 0x0001;      // play asynchronously
	public static int SND_NODEFAULT   = 0x0002;      // silence (!default) if sound not found
	public static int SND_MEMORY      = 0x0004;      // pszSound points to a memory file
	public static int SND_LOOP        = 0x0008;      // loop the sound until next sndPlaySound
	public static int SND_NOSTOP      = 0x0010;      // don't stop any currently playing  sound
	public static int SND_NOWAIT      = 0x00002000; // don't wait if the driver is busy
	public static int SND_ALIAS       = 0x00010000; // name is a Registry alias
	public static int SND_ALIAS_ID    = 0x00110000; // alias is a predefined ID
	public static int SND_FILENAME    = 0x00020000; // name is file name
	public static int SND_RESOURCE    = 0x00040004; // name is resource name or atom
	public static int SND_PURGE       = 0x0040;     // purge non-static events for task
	public static int SND_APPLICATION = 0x0080;     // look for application-specific association
        private Thread t; // used for pausing
        private string bname;
        private int soundFlags;
	//-----------------------------------------------------------------
	public void Play(string wfname, int SoundFlags)
	{
		byte[] bname = new Byte[256];    //Max path length
		bname = System.Text.Encoding.ASCII.GetBytes(wfname);
                this.bname = bname;
                this.soundFlags = SoundFlags;
                t = new Thread(play);
                t.Start();
	}
	//-----------------------------------------------------------------
        private void play()
        {
               PlaySound(bname, soundFlags)
        }        
	public void StopPlay()
	{
               t.Stop();
	}
       public void Pause()
       {
               t.Suspend(); // yeah, I know its obsolete, but it works
       }
       public void Resume()
       {
               t.Resume(); // yeah, I know its obsolete, but it works
       }
