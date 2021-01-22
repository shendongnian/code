    List<Rectangle> rectangles = new List<Rectangle>();
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (stayToolStripMenuItem.Checked == true)
            {
                if (mybitmap == null)
                {
                    mybitmap = new Bitmap(sz.Width, sz.Height);
                }
                rect = new Rectangle(e.X, e.Y, 0, 0);
                this.Invalidate();
            }
             
        }
       
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (stayToolStripMenuItem.Checked == true)
            {
                button1.Visible = true;
                button2.Visible = true;
                if (mybitmap == null)
                {
                    return;
                }
                
                    using (g = Graphics.FromImage(mybitmap))
                    {
                        using (Pen pen = new Pen(Color.Red, 2))
                        {
                            //g.Clear(Color.Transparent);
                            e.Graphics.DrawRectangle(pen, rect);
                            label1.Top = rect.Top; label1.Left = rect.Left; label1.Width = rect.Width;
                            label1.Height = rect.Height;
                            if (label1.TextAlign == ContentAlignment.TopLeft)
                            {
                                e.Graphics.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), rect);
                                g.DrawString(label1.Text, label1.Font, new SolidBrush(label1.ForeColor), rect);
                                g.DrawRectangle(pen, rect);
                            }
                        }
                    }
    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
                if (e.Button == MouseButtons.Left)
                
                {
                    rect = new Rectangle(rect.Left, rect.Top, e.X - rect.Left, e.Y - rect.Top);
                    rectangles.Add(rect);
                    pictureBox1.Invalidate();
                    f = 0;
                }
           
        }
