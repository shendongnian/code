    private void button1_Click(object sender, EventArgs e)
    {
        using (Graphics g = this.CreateGraphics())
        {
            LinearGradientBrush lgb = new LinearGradientBrush(new Point(0, 0), new Point(210, 0), Color.Red, Color.Green);
            Pen p = new Pen(lgb, 10);
            g.DrawArc(p, 10, 10, 200, 200, -22.5f, -135f);
        }
    }
