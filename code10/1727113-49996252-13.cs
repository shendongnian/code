    RectangleF ChartAreaClientRectangle(Chart chart, ChartArea CA)
    {
        RectangleF CAR = CA.Position.ToRectangleF();
        float pw = chart.ClientSize.Width / 100f;
        float ph = chart.ClientSize.Height / 100f;
        return new RectangleF(pw * CAR.X, ph * CAR.Y, pw * CAR.Width, ph * CAR.Height);
    }
    RectangleF InnerPlotPositionClientRectangle(Chart chart, ChartArea CA)
    {
        RectangleF IPP = CA.InnerPlotPosition.ToRectangleF();
        RectangleF CArp = ChartAreaClientRectangle(chart, CA);
        float pw = CArp.Width / 100f;
        float ph = CArp.Height / 100f;
        return new RectangleF(CArp.X + pw * IPP.X, CArp.Y + ph * IPP.Y, 
                                pw * IPP.Width, ph * IPP.Height);
    }
