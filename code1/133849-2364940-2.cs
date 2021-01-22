     private void btnplay_Click(object sender, EventArgs e)
    {
        if (ofd.FileName == "")
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ofd.Filter = "MP3 Files|*.mp3";
                CommandString = "open " + "\"" + ofd.FileName + "\"" + " type MPEGVideo alias Mp3File";
                mciSendString(CommandString, null, 0, this.Handle.ToInt64());
                CommandString = "play Mp3File";
                mciSendString(CommandString, null, 0, this.Handle.ToInt64());
            }
        }
        else
        {
            CommandString = "play Mp3File";
            mciSendString(CommandString, null, 0, this.Handle.ToInt64());
        }
    }
    // Declare the nofify constant
    public const int MM_MCINOTIFY = 953;
    // Override the WndProc function in the form
    protected override void WndProc(ref Message m) 
    {
   
        if (m.Msg == MM_MCINOTIFY)
        {
            // The file is done playing, do whatever
        }
        base.WndProc(ref m);
    }
  
