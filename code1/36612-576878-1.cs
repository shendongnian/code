    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
    
        Graphics graphicsObject = e.Graphics;
    
        using (Brush aGradientBrush = new LinearGradientBrush(new Point(0, 0), new Point(50, 0), Color.Blue, Color.Red))
        {
            using (Pen aGradientPen = new Pen(aGradientBrush))
            {
                graphicsObject.DrawLine(aGradientPen, new Point(0, 10), new Point(100, 10));
            }
        }
    }
