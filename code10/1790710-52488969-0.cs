    private void canvasForm_Paint(object sender, PaintEventArgs e)
    {
        draw(sender as Control, e.Graphics);
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        draw(sender as Control, e.Graphics);
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        draw(sender as Control, e.Graphics);
    }
    private void draw(Control ctl, Graphics g)
    {
        Rectangle r = new Rectangle(200, 100, 75, 75);
        if (ctl != canvasForm)  g.TranslateTransform(-ctl.Left, -ctl.Top);
        g.FillEllipse(Brushes.Green, r);
        g.ResetTransform();
    }
