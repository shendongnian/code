    private void button1_Click(object sender, EventArgs e)
    {
        System.Drawing.Graphics formGraphics = this.CreateGraphics();
        GraphicsPath graphicsPath = new GraphicsPath();
        graphicsPath.AddRectangle(ClientRectangle);
        PathGradientBrush pgb = new PathGradientBrush(graphicsPath);
        pgb.CenterPoint = new PointF(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
        pgb.CenterColor = Color.White;
        pgb.SurroundColors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Yellow };
        formGraphics.FillPath(pgb, graphicsPath);
        pgb.Dispose();
        formGraphics.Dispose();
    }
