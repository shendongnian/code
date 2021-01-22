    int alpha = 0;
...
    private void timer1_Tick(object sender, EventArgs e)
    {
    	if (alpha++ < 255)
    	{
    		Image image = pictureBox1.Image;
    		using (Graphics g = Graphics.FromImage(image))
    		{
    			Pen pen = new Pen(Color.FromArgb(alpha, 255, 255, 255), image.Width);
    			g.DrawLine(pen, -1, -1, image.Width, image.Height);
    			g.Save();
    		}
    		pictureBox1.Image = image;
    	}
    	else
    	{
    		timer1.Stop();
    	}
    }
