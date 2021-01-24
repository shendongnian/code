    private void Note_MouseDown(object sender, MouseEventArgs e)
    {
        var mn = sender as MusicNote;
        if (mn != null) 
        {
            if (e.Button == MouseButtons.Right)
            {
                count = 0;
                mn.timer1.Start();
                sp.SoundLocation = MusicNote_path + mn.note + ".wav";
                sp.Play();
            }
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                mn.BackColor = Color.HotPink;
            }
        }
    }
