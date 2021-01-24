    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        int x = pictureBox1.Location.X;
        int y = pictureBox1.Location.Y;
        if (e.KeyCode == Keys.W) y -= chrspeed;
        else if (e.KeyCode == Keys.A) x -= chrspeed;
        else if (e.KeyCode == Keys.D) x += chrspeed;
        else if (e.KeyCode == Keys.S) y += chrspeed;
 
        method(new Rectangle(x, y, pictureBox1.Width, pictureBox1.Height), pictureBox2 );
        if (movement == true)
        {
            pictureBox1.Location = new Point(x, y);
        }
            
    }
