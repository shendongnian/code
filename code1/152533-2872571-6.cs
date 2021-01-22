    Image bac;
    Bitmap myBitmap;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (mybitmap == null)
        {
            mybitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());
        }
        rect = new Rectangle(e.X, e.Y, 0, 0);
        this.Invalidate();
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        switch (e.Button)
        {
            case MouseButtons.Left:
            {
                rect = new Rectangle(rect.Left, rect.Top, e.X - rect.Left, e.Y - rect.Top);
                this.Invalidate();
                break;
            }
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (mybitmap == null)
        {
            return;
        }
        using (Pen pen = new Pen(Color.Red, 2))
        {
            using (Graphics g = Graphics.FromImage(mybitmap))
            {
                e.Graphics.DrawRectangle(pen, rect);
                
                if (label1.TextAlign == ContentAlignment.TopLeft)
                {
                    e.Graphics.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), label1.Bounds); 
                    g.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), label1.Bounds);
                }
                else if (label1.TextAlign == ContentAlignment.TopCenter)
                {
                    SizeF size = e.Graphics.MeasureString(label1.Text, label1.Font);
                    float left = ((float)this.Width + label1.Left) / 2 - size.Width / 2;
                    RectangleF rect1 = new RectangleF(left, (float)label1.Top, size.Width, label1.Height);
                    e.Graphics.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), rect1);
                }
                else
                {
                    SizeF size = e.Graphics.MeasureString(label1.Text, label1.Font);
                    float left = (float)label1.Width - size.Width + label1.Left;
                    RectangleF rect1 = new RectangleF(left, (float)label1.Top, size.Width, label1.Height);
                    e.Graphics.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), rect1);
                }
           }
        }
    }
    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (mybitmap != null)
        {
            SaveFileDialog SaveFD1 = new SaveFileDialog();
            SaveFD1.FileName = "";
            SaveFD1.InitialDirectory = "C";
            SaveFD1.Title = "save file Name";
            SaveFD1.Filter = "JPG|*.jpg|Bmp|*.bmp";
            if (SaveFD1.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream filename = (System.IO.FileStream)SaveFD1.OpenFile();
                int r = SaveFD1.FileName.Length;
                for (int r1 = 0; r1 <= r; )
                {
                    if (SaveFD1.FileName[r1] != '.')
                        r1++;
                    else
                    {
                        r = r1;
                        break;
                    }
                }
                if (SaveFD1.FileName[++r] == 'j')
                {
                    using (Graphics g = Graphics.FromImage(bac))
                    {
                        g.DrawImage(mybitmap, 0, 0);
                    }
                    bac.Save(filename, ImageFormat.Jpeg);
                }
                else if (SaveFD1.FileName[r] == 'b')
                {
                    using (Graphics g = Graphics.FromImage(bac))
                    {
                        g.DrawImage(mybitmap, 0, 0);
                    }
                    bac.Save(filename, ImageFormat.Jpeg);
                }
                else
                {
                    using (Graphics g = Graphics.FromImage(bac))
                    {
                        g.DrawImage(mybitmap, 0, 0);
                    }
                    bac.Save(filename, ImageFormat.Png);
                }
                filename.Close();
            }
        }
    }
    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFD.FileName = "";
        OpenFD.Title = "open image";
        OpenFD.InitialDirectory = "C";
        OpenFD.Filter = "JPEG|*.jpg|Bmp|*.bmp|All Files|*.*.*";
        if (OpenFD.ShowDialog() == DialogResult.OK)
        {
            file = OpenFD.FileName;
            bac = Image.FromFile(file);
            pictureBox1.Image = bac;
            pictureBox1.Invalidate();
        }
    }
