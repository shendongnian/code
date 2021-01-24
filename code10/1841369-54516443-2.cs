    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        // i want to loop only over line annotations:
        List<LineAnnotation> annos =
            chart1.Annotations.Where(x => x is LineAnnotation)
                                .Cast<LineAnnotation>().ToList();
        if (!annos.Any()) return;
        // a few short references
        Graphics g = e.ChartGraphics.Graphics;
        ChartArea ca = chart1.ChartAreas[0];
        Axis ax = ca.AxisX;
        Axis ay = ca.AxisY;
        // we want to clip the line to the innerplotposition excluding the scrollbar:
        Rectangle r = Rectangle.Round(InnerPlotPositionClientRectangle(chart1, ca));
        g.SetClip(new Rectangle(r.X, r.Y, r.Width, r.Height - (int)ax.ScrollBar.Size));
        // pick your mode!
        g.InterpolationMode = InterpolationMode.NearestNeighbor;
        foreach (LineAnnotation la in annos)
        {
            if (la == null) continue;
            if (Double.IsNaN(la.Width)) continue;  // *
            // calculate the coordinates
            int x1 = (int)ax.ValueToPixelPosition(la.AnchorX);
            int y1 = (int)ay.ValueToPixelPosition(la.AnchorY);
            int x2 = (int)ax.ValueToPixelPosition(la.AnchorX + la.Width);
            int y2 = (int)ay.ValueToPixelPosition(la.AnchorY + la.Height);
            // now we draw the line if necessary:
            if (x1 < r.X || x1 > r.Right)
                using (Pen pen = new Pen(la.LineColor, 0.5f)) g.DrawLine(pen, x1, y1, x2, y2);
        }
        // reset the clip to allow the system drawing a scrollbar
        g.ResetClip();
    }
