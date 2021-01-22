    private void timer1_Tick(object sender, EventArgs e)
    {
        if (xOffset < 500)
            xOffset += 2;
        else
            timer1.Enabled = false; // This will make it only move 500 pixels before stopping.... Change as desired.
        this.Invalidate(); // Forces repaint
    }
