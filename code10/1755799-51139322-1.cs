    DateTime? lastMovement;
    bool hidden = false;
    int duration = 2;
    void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        lastMovement = DateTime.Now;
        if (hidden)
        {
            Cursor.Show();
            hidden = false;
        }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (!lastMovement.HasValue)
            return;
        TimeSpan elaped = DateTime.Now - lastMovement.Value;
        if (elaped >= TimeSpan.FromSeconds(duration) && !hidden)
        {
            Cursor.Hide();
            hidden = true;
        }
    }
