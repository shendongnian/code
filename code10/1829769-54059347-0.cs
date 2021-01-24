    private void Note_MouseDown(object sender, MouseEventArgs e)
    {
        // If neither right nor left is down, return immediately because nothing needs 
        // to be done.
        if (!(e.Button == MouseButtons.Right || e.Button == MouseButtons.Left))
        {
            return;
        }
        // This should not fail, if it does, then ask yourself why have you created 
        // this handler for things which are not MusicNote.
        MusicNote mn = (MusicNote)sender;
        // Do some work below
        if (e.Button == MouseButtons.Right)
        {
            count = 0;
            timer1.Start();
            sp.SoundLocation = MusicNote_path + mn.note + ".wav";
            sp.Play();
        }
        if (e.Button == MouseButtons.Left)
        {
            dragging = true;
            mn.BackColor = Color.HotPink;
        }
    }
