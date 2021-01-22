    private void Form1_Load(object sender, EventArgs e)
    {
        Bitmap bmp2;
          
        using (Bitmap bmp1 = new Bitmap(@"C:\temp\pretty.bmp"))
        {
    //Edit: Clone was keeping a link between bmp1 and bmp2 somehow
           // bmp2 = (Bitmap)bmp1.Clone();
           IntPtr hbmp = bmp1.GetHbitmap();
           bmp2 = Bitmap.FromHbitmap(hbmp);     
        }
    
        using (Graphics g = Graphics.FromImage(bmp2))
        using (Brush b = new SolidBrush(Color.Red))
        {
            g.FillRectangle(b, 0, 0, 49, 49);
    
            bmp2.Save(@"C:\temp\pretty.bmp");
        }
    
        this.pictureBox1.Image = bmp2;   
    }
