    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        var colorArray = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Yellow };        
        GraphicsPath graphicsPath = new GraphicsPath();
        graphicsPath.AddRectangle(ClientRectangle);
        using (Graphics graphics = this.CreateGraphics())
        using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath)
        {
            CenterColor = Color.FromArgb((int)colorArray.Average(a => a.R), (int)colorArray.Average(a => a.G), (int)colorArray.Average(a => a.B)),
            SurroundColors = colorArray
        })
        {
            graphics.FillPath(pathGradientBrush, graphicsPath);
        }
    }
