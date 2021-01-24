    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (pictureBox1.Left >= 0 && pictureBox1.Right <= panel1.Width)
                pictureBox1.Left += (e.X - x);
                    
            pictureBox1.Left = Math.Min(panel1.Width - pictureBox1.Width , pictureBox1.Left);
            pictureBox1.Left = Math.Max(0, pictureBox1.Left);
        }
    }
