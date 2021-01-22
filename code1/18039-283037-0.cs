    private void label1_Paint(object sender, PaintEventArgs e)
    {
        System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new  System.Drawing.Drawing2D.GraphicsPath();
        myGraphicsPath.AddEllipse(new Rectangle(0, 0, 125, 125));
        myGraphicsPath.AddEllipse(new Rectangle(75, 75, 20, 20));
        myGraphicsPath.AddEllipse(new Rectangle(120, 0, 125, 125));
        myGraphicsPath.AddEllipse(new Rectangle(145, 75, 20, 20));
        //Change the button's background color so that it is easy
        //to see.
        label1.BackColor = Color.ForestGreen;
        label1.Size = new System.Drawing.Size(256, 256);
        label1.Region = new Region(myGraphicsPath);
    }
