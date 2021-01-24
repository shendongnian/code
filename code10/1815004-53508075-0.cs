    private void chart7_MouseMove(object sender, MouseEventArgs e)
    {
        if (zoomPBox.Image == null) return;
        Rectangle ri = Rectangle.Round(InnerPlotPositionClientRectangle(chart, chart.ChartAreas[0]));
        //Size szc = chart.ClientSize;
        Size szi = zoomPBox.Image.Size;
        Size szp = zoomPanel.ClientSize;
        Point cp = new Point( e.X - ri.X ,  e.Y - ri.Y );
        float zx = 1f * szi.Width / ri.Width;
        float zy = 1f * szi.Height / ri.Height;  // should be the same
        int x = round( szp.Width / 2 - cp.X * zx );
        int y = round( szp.Height / 2 - cp.Y * zy );
        zoomPBox.Location = new Point(x, y);     // now we move the pBox into position
        zoomPBox.Invalidate();
    }
