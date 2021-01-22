    private bool pb_mouseIsDown;
    private int oX;
    private int oY;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        pb_mouseIsDown = true;
        oX = e.X;
        oY = e.Y;
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        pb_mouseIsDown = false;
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (pb_mouseIsDown)
        {
            pictureBox1.Left += e.X - oX;
            pictureBox1.Top += e.Y - oY;
        }
    }
