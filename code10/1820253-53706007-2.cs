    private void chart2_PostPaint(object sender, ChartPaintEventArgs e)
    {
        if (chart2.Series[0].Points.Count <= 0) return;
        Axis ax = chart2.ChartAreas[0].AxisX;
        Axis ay = chart2.ChartAreas[0].AxisY;
        Graphics g = e.ChartGraphics.Graphics;
        using (StringFormat fmt = new StringFormat()
        { Alignment = StringAlignment.Center, 
          LineAlignment = StringAlignment.Center})
            foreach (Series s in chart2.Series)
            {
                List<Rectangle> rex = new List<Rectangle>();
                foreach (DataPoint dp in s.Points)
                {
                    if (dp.Tag == null) break;
                    SizeF sz = (SizeF)dp.Tag;
                    double vx2 = dp.XValue + sz.Width;
                    double vy2 = dp.YValues[0] + sz.Height;
                    int x1 = (int)ax.ValueToPixelPosition(dp.XValue);
                    int y1 = (int)ay.ValueToPixelPosition(dp.YValues[0]);
                    int x2 = (int)ax.ValueToPixelPosition(vx2);
                    int y2 = (int)ay.ValueToPixelPosition(vy2);
                    rex.Add(Rectangle.FromLTRB(x1, y2, x2, y1));
                    using (Pen pen = new Pen(s.Color, 2f))
                        g.DrawRectangle(pen, rex.Last());
                    g.DrawString(dp.Label, Font, Brushes.Black, rex.Last(), fmt);
                }
            }
    }
