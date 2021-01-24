    private void chart1_MouseHover(object sender, EventArgs e)
    {
        var p = chart1.PointToClient(MousePosition);
        var result = chart1.HitTest(p.X, p.Y);
        if (result.ChartElementType == ChartElementType.DataPoint)
        {
            var xV = chart1.Series[0].Points[result.PointIndex].XValue;
            chart1.ChartAreas[0].CursorX.SetCursorPosition(xV);
        }
    }
