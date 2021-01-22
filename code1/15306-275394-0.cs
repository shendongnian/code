    using System.Drawing.Imaging;
    using System.Drawing.Drawing2D;
    
    public int alphablend;
    public Bitmap myBitmap;
        
        private void button1_Click(object sender, EventArgs e)
        {
            alphablend = 0;
            pictureBox1.Visible = true;
            myBitmap = new Bitmap(tabControl1.Width, tabControl1.Height);
            while (alphablend <= 246)
            {
                tabControl1.DrawToBitmap(myBitmap, new Rectangle(0, 0, tabControl1.Width, tabControl1.Height));
                alphablend = alphablend + 10;
                pictureBox1.Refresh();//this calls the paint action
            }
            tabControl1.SelectTab("tabPage2");
            while (alphablend >= 0)
            {
                tabControl1.DrawToBitmap(myBitmap, new Rectangle(0, 0, tabControl1.Width, tabControl1.Height));
                alphablend = alphablend - 10;               
                pictureBox1.Refresh();//this calls the paint action
            }
            pictureBox1.Visible = false;
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics bitmapGraphics = Graphics.FromImage(myBitmap);
            SolidBrush greyBrush = new SolidBrush(Color.FromArgb(alphablend, 240, 240, 240));
            
            bitmapGraphics.CompositingMode = CompositingMode.SourceOver;
            bitmapGraphics.FillRectangle(greyBrush, new Rectangle(0, 0, tabControl1.Width, tabControl1.Height));
            e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
            e.Graphics.DrawImage(myBitmap, 0, 0);
        }
