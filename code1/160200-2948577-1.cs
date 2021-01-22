    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (mybitmap == null)
           return;
    
        using (g = Graphics.FromImage(mybitmap))
        using (Pen pen = new Pen(Color.Red, 2))
        {
            g.Clear(Color.Transparent);
    
            for (int i = 0; i < count; i++)
            {
                // Code to draw rect[i], instead of rect[count]
            }
        }
    }
