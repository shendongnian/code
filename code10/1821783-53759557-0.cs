        MemoryStream ms;
    
    private void button1_Click(object sender, EventArgs e)
    {
        
        ms = new MemoryStream();
        using (FileStream stream = File.OpenRead(FullName))
        {
            stream.CopyTo(ms);
            pictureBox1.Image = Bitmap.FromStream(ms);
        }
    }        
    
    
    private void button2_Click(object sender, EventArgs e)
    {
        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
        {
            g.Clear(Color.FromArgb(0, 255, 255, 255));
        }     
    }
