    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle r1 = new Rectangle(100, 100, 150, 150);
        Rectangle r2 = new Rectangle(195, 100, 150, 150);
        Rectangle r3 = new Rectangle(145, 190, 150, 150);
        GraphicsPath gp1 = new GraphicsPath();
        GraphicsPath gp2 = new GraphicsPath();
        GraphicsPath gp3 = new GraphicsPath();
        gp1.AddEllipse(r1);
        gp2.AddEllipse(r2);
        gp3.AddEllipse(r3);
        Region r_1 = new Region(gp1);
        Region r_2 = new Region(gp2);
        Region r_3 = new Region(gp3);
        r_1.Intersect(r_2);   // just two of five..
        r_1.Exclude(r_3);     // set operations supported!
        g.SetClip(r_1, CombineMode.Replace);
        g.Clear(Color.Magenta);    // fill the remaining region
        g.ResetClip();
        g.DrawEllipse(Pens.Red, r1);
        g.DrawEllipse(Pens.Blue, r2);
        g.DrawEllipse(Pens.Green, r3);
       // finally dispose of all Regions and GraphicsPaths!!
        r_1.Dispose();
        gp1.Dispose();
        .....
    }
