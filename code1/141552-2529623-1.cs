    private void pictureBox1_Click(object sender, EventArgs e)
    {
    	if (pictureBox1.Image == null)
    	{
        		pictureBox1.Image = new Bitmap(pictureBox1.width, 
                        pictureBox1.height);
    	}
    	using (Graphics g = Graphics.FromImage(pictureBox1.Image))
    	{
    		// draw black background
    		g.Clear(Color.Black);
    		Rectangle rect = new Rectangle(100, 100, 200, 200);
    		g.DrawRectangle(Pens.Red, rect);
    	}
    	pictureBox1.Invalidate();
    }
