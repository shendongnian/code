    private void Form1_Load(object sender, EventArgs e)
    {
        // declare flowlayout panel
        FlowLayoutPanel fl = new FlowLayoutPanel();
        fl.Size = new Size(500, 800);
        // this will add a scroll bar when the children height are greater than the height
        fl.AutoScroll = true;
        this.Controls.Add(fl);
        // add pictureboxes that shows the bitmaps
        for (int i = 0; i < 20; i++)
        {
            Bitmap b = new Bitmap(@"C:\Users\xxx\xxx\xxx.png");
            PictureBox p = new PictureBox();
            p.Image = b;
            p.Size = new Size(fl.Width, 50);
            fl.Controls.Add(p);
        }
    }
